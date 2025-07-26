using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            // TODO: 实际调用 LLM，例如通过 OpenAI API
            var content = $"这是针对您的提示生成的示例回答: {request.Prompt}";
            await Task.CompletedTask;
            return Ok(new { content });
        }

        public class GenerateRequest
        {
            public string Prompt { get; set; } = string.Empty;
            public List<string>? Documents { get; set; }
        }
    }
}