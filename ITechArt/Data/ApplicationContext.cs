using ITechArt.Models.ForDatabase;
using Microsoft.EntityFrameworkCore;

namespace ITechArt.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
