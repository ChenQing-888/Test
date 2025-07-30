using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SmartAI.ChatService
{
    public class ChatServiceDbContext : AbpDbContext<ChatServiceDbContext>
    {
        public ChatServiceDbContext(DbContextOptions<ChatServiceDbContext> options)
            : base(options)
        {
        }

        // 定义 Chat 相关实体，如会话、消息等
        // public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
