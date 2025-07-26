using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartAI.AdminUI.Controllers
{
    [Route("api/admin")]
    public class AdminController : AbpController
    {
        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "AdminUI service is running" });
        }
    }
}