using Microsoft.EntityFrameworkCore;
namespace PortfolioApi.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
        {
        }

        public DbSet<BlogItem> BlogItems { get; set; } = null!;
    }
}
