using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.BackgroundJobs;
using System.Threading.Tasks;

namespace SmartAI.BackgroundJobs.Controllers
{
    [Route("api/jobs")] 
    public class JobsController : AbpController
    {
        private readonly IBackgroundJobManager _jobManager;
        public JobsController(IBackgroundJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        [HttpGet("health")] 
        public IActionResult GetHealth()
        {
            return Ok(new { status = "BackgroundJobs service is running" });
        }

        /// <summary>
        /// 发布一个示例后台作业，该作业只是等待 1 秒输出日志。
        /// </summary>
        [HttpPost("enqueue-sample")] 
        public async Task<IActionResult> EnqueueSampleJob()
        {
            await _jobManager.EnqueueAsync(new SampleJobArgs { Message = "Hello from background job" });
            return Ok(new { result = "Job enqueued" });
        }
    }

    /// <summary>
    /// 示例后台作业参数
    /// </summary>
    public class SampleJobArgs
    {
        public string Message { get; set; } = string.Empty;
    }

    /// <summary>
    /// 示例后台作业实现。它仅记录一条消息。
    /// </summary>
    public class SampleJob : AsyncBackgroundJob<SampleJobArgs>
    {
        public override async Task ExecuteAsync(SampleJobArgs args)
        {
            Logger.LogInformation("执行后台作业: {Message}", args.Message);
            await Task.Delay(1000);
            Logger.LogInformation("后台作业执行完成");
        }
    }
}