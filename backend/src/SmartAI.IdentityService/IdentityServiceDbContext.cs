using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SmartAI.IdentityService
{
    /// <summary>
    /// DbContext 示例，您可以在此定义用户、角色、组织等实体。
    /// </summary>
    public class IdentityServiceDbContext : AbpDbContext<IdentityServiceDbContext>
    {
        public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options)
            : base(options)
        {
        }

        // 示例：定义一个简单的实体集合
        // public DbSet<AppUser> Users { get; set; }
    }
}
