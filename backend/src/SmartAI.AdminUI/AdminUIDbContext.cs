using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SmartAI.AdminUI
{
    public class AdminUIDbContext : AbpDbContext<AdminUIDbContext>
    {
        public AdminUIDbContext(DbContextOptions<AdminUIDbContext> options)
            : base(options)
        {
        }

        // 定义管理后台相关实体
    }
}