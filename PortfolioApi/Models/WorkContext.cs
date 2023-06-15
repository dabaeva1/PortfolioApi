using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Models
{
    public class WorkContext: DbContext
    {
        public WorkContext(DbContextOptions<WorkContext> options)
        : base(options)
    {
        }

        public DbSet<WorkItem> WorkItems { get; set; } = null!;
    }
}
