using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartAI.IdentityService
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpAspNetCoreMvcModule)
    )]
    public class IdentityServiceModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            // 添加 EF Core DbContext，示例中未定义实体，仅用于演示
            services.AddAbpDbContext<IdentityServiceDbContext>(options => { });
        }
    }
}