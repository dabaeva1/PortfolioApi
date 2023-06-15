using Microsoft.EntityFrameworkCore;
namespace PortfolioApi.Models
{
    public class AboutContext: DbContext
    {
        public AboutContext(DbContextOptions<AboutContext> options)
        : base(options)
        {
        }

        public DbSet<AboutItem> AboutItems { get; set; } = null!;
    }
}
