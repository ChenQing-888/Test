using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartAI.IdentityService.Controllers
{
    [Route("api/identity")] 
    public class IdentityController : AbpController
    {
        /// <summary>
        /// 健康检查接口，返回服务是否正常。
        /// </summary>
        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "IdentityService is running" });
        }
    }
}
