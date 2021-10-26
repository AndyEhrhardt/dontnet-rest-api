using Microsoft.EntityFrameworkCore;

namespace GlassesApi.Models
{
    public class GlassesContext : DbContext
    {
        public GlassesContext(DbContextOptions<GlassesContext> options)
            : base(options)
        {
        }

        public DbSet<GlassesItem> GlassesItems { get; set; }
    }
}