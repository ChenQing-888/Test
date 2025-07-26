using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartAI.AIIntegrationService
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpAspNetCoreMvcModule)
    )]
    public class AIIntegrationServiceModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddAbpDbContext<AIIntegrationServiceDbContext>(options => { });
        }
    }
}