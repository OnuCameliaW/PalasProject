namespace Interns
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class InternDb : DbContext
    {
        public DbSet<Intern> Interns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Interns;Trusted_Connection=True;");
        }
    }
}