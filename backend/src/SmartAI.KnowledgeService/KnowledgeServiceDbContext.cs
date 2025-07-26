using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SmartAI.KnowledgeService
{
    public class KnowledgeServiceDbContext : AbpDbContext<KnowledgeServiceDbContext>
    {
        public KnowledgeServiceDbContext(DbContextOptions<KnowledgeServiceDbContext> options)
            : base(options)
        {
        }

        // 定义知识库相关实体：文档、向量索引等
        // public DbSet<Document> Documents { get; set; }
    }
}