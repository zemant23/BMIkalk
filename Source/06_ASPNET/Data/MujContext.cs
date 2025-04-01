using Microsoft.EntityFrameworkCore;
using _06_ASPNET.Models;

namespace _06_ASPNET.Data
{
    public class MujContext : DbContext
    {
        public MujContext(DbContextOptions<MujContext> options)
            : base(options)
        { }

        public DbSet<Uzivatel> Uzivatele { get; set; }
    }
}
