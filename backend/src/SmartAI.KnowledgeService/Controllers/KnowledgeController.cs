using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SmartAI.KnowledgeService.Controllers
{
    [Route("api/knowledge")] 
    public class KnowledgeController : AbpController
    {
        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "KnowledgeService is running" });
        }

        /// <summary>
        /// 简单检索接口示例。根据查询返回模拟的文档列表。实际实现应连接向量数据库并返回 Top‑K。
        /// </summary>
        /// <param name="query">用户输入的查询字符串。</param>
        [HttpGet("search")] 
        public IActionResult Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(new { items = new List<object>() });
            }
            var items = new List<object>
            {
                new { id = 1, title = "示例文档一", snippet = "与查询 \"" + query + "\" 相关的文档内容片段。", score = 0.9 },
                new { id = 2, title = "示例文档二", snippet = "另一个关于 \"" + query + "\" 的示例文档。", score = 0.8 }
            };
            return Ok(new { items });
        }
    }
}
