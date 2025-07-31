using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;

namespace SmartAI.AIIntegrationService.Controllers
{
    [Route("api/ai")] 
    public class AIController : AbpController
    {
        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "AIIntegrationService is running" });
        }

        /// <summary>
        /// 调用 LLM 的示例接口。请求包含用户输入和检索的文档信息。
        /// </summary>
        /// <param name="request">生成请求</param>
        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] GenerateRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Prompt))
            {
                return BadRequest(new { error = "prompt cannot be empty" });
            }

            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return StatusCode(500, new { error = "OPENAI_API_KEY not configured" });
            }

            var docs = request.Documents != null ? string.Join("\n", request.Documents) : string.Empty;

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new object[]
                {
                    new { role = "system", content = $"参考文档: {docs}" },
                    new { role = "user", content = request.Prompt }
                }
            };

            using var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var resp = await http.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var respJson = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode)
            {
                return StatusCode((int)resp.StatusCode, respJson);
            }

            var result = JsonSerializer.Deserialize<OpenAIResponse>(respJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var answer = result?.Choices?.FirstOrDefault()?.Message?.Content ?? string.Empty;
            return Ok(new { content = answer });
        }

        public class OpenAIResponse
        {
            public List<Choice>? Choices { get; set; }
        }

        public class Choice
        {
            public Message? Message { get; set; }
        }

        public class Message
        {
            public string? Content { get; set; }
        }

        public class GenerateRequest
        {
            public string Prompt { get; set; } = string.Empty;
            public List<string>? Documents { get; set; }
        }
    }
}
