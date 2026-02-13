using Microsoft.EntityFrameworkCore;
using urlshortner.Models;

namespace urlshortner.Data
{
    public class AppContextDb : DbContext
    {
        public DbSet<UrlManagement> Urls { get; set; }
        public AppContextDb(DbContextOptions<AppContextDb> options)  : base(options)
        {
        }

    }
}
