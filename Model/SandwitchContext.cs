using Microsoft.EntityFrameworkCore;

namespace WebAPISandwitch.Model
{
    public class SandwitchContext : DbContext
    {
        public SandwitchContext(DbContextOptions<SandwitchContext> options):base(options) {     
        }
        static string connectionstring = @"Data Source=DESKTOP-ABDUL\SQLEXPRESS;Initial Catalog=AbdulDB;TrustServerCertificate= True; Integrated Security=True";
        public  DbSet<Sandwitch> Sandswitches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             base.OnConfiguring(optionsBuilder);

            //Configuring DB connection
            optionsBuilder.UseSqlServer(connectionstring);
        }
    }
}
