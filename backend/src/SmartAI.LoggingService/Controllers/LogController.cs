using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartAI.LoggingService.Controllers
{
    [Route("api/log")] 
    public class LogController : AbpController
    {
        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "LoggingService is running" });
        }
    }
}
