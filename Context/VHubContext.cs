using Microsoft.EntityFrameworkCore;
using WebApplication1.Modelos;

namespace WebApplication1.Context
{
    public class VHubContext : DbContext
    {

        public DbSet<Cliente> Cliente { get; set; }


        public VHubContext(DbContextOptions<VHubContext> options) : base(options)
        { 

        }

        public void AplicarMigracoes()
        {
            if (this.Database.IsRelational() && this.Database.GetPendingMigrations().Any())
            {
                this.Database.Migrate();
            }
        }



    }
}
