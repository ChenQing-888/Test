using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SmartAI.AIIntegrationService
{
    public class AIIntegrationServiceDbContext : AbpDbContext<AIIntegrationServiceDbContext>
    {
        public AIIntegrationServiceDbContext(DbContextOptions<AIIntegrationServiceDbContext> options)
            : base(options)
        {
        }

        // 定义 Prompt 模板等实体
    }
}
