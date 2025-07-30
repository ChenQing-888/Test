using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.HangFire;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartAI.BackgroundJobs
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpBackgroundJobsHangFireModule),
        typeof(AbpAspNetCoreMvcModule)
    )]
    public class BackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // 配置后台作业，如计划任务
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            // 这里可以注册后台作业
        }
    }
}
