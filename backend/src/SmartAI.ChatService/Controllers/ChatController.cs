using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;

namespace SmartAI.ChatService.Controllers
{
    [Route("api/chat")] 
    public class ChatController : AbpController
    {
        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "ChatService is running" });
        }

        /// <summary>
        /// 简单的问答接口示例。实际实现应根据用户问题调用 KnowledgeService 和 AIIntegrationService。
        /// </summary>
        /// <param name="request">包含用户问题的请求对象。</param>
        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] AskRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Question))
            {
                return BadRequest(new { error = "question cannot be empty" });
            }

            var knowledgeUrl = Environment.GetEnvironmentVariable("KNOWLEDGE_SERVICE_URL") ?? "http://localhost:5002";
            var aiUrl = Environment.GetEnvironmentVariable("AI_SERVICE_URL") ?? "http://localhost:5003";

            using var http = new HttpClient();

            // 调用 KnowledgeService 获取相关文档
            var searchResp = await http.GetAsync($"{knowledgeUrl}/api/knowledge/search?query={Uri.EscapeDataString(request.Question)}");
            var searchJson = await searchResp.Content.ReadAsStringAsync();
            var search = JsonSerializer.Deserialize<SearchResult>(searchJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var docs = new List<string>();
            if (search?.Items != null)
            {
                foreach (var item in search.Items)
                {
                    if (!string.IsNullOrWhiteSpace(item.Snippet))
                    {
                        docs.Add(item.Snippet);
                    }
                }
            }

            // 调用 AIIntegrationService 生成回答
            var aiRequest = new AIRequest { Prompt = request.Question, Documents = docs };
            var aiContent = new StringContent(JsonSerializer.Serialize(aiRequest), Encoding.UTF8, "application/json");
            var aiResp = await http.PostAsync($"{aiUrl}/api/ai/generate", aiContent);
            var aiJson = await aiResp.Content.ReadAsStringAsync();
            var ai = JsonSerializer.Deserialize<AIResponse>(aiJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var answer = ai?.Content ?? string.Empty;
            return Ok(new { answer });
        }

        public class SearchResult
        {
            public List<SearchItem>? Items { get; set; }
        }

        public class SearchItem
        {
            public string? Snippet { get; set; }
        }

        public class AIResponse
        {
            public string? Content { get; set; }
        }

        public class AskRequest
        {
            public string Question { get; set; } = string.Empty;
        }
    }
}
