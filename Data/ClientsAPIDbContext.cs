using Microsoft.EntityFrameworkCore;

namespace PetClient.Data
{
    public class ClientsAPIDbContext : DbContext
    {
        public ClientsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Client> Clients { get; set; }  
    }
}
