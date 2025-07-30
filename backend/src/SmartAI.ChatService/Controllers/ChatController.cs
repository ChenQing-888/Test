using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            // TODO: 调用 KnowledgeService 和 AIIntegrationService 返回真实答案
            var answer = $"您问的是: {request.Question}. 目前仅返回示例答案。";
            await Task.CompletedTask;
            return Ok(new { answer });
        }

        public class AskRequest
        {
            public string Question { get; set; } = string.Empty;
        }
    }
}
