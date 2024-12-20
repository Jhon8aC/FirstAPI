using FirstAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
