using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Url;

namespace UrlShortener.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UrlEntry> UrlEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
