using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {       
        public DataContext(DbContextOptions options) : base(options){}
        public DbSet<UserApp>userApps { get; set; }
        public DbSet<ClientApp> clientApps { get; set; }

        public DbSet<Contatos> contatos { get; set; }
                
   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Contatos>()
            .HasOne(c => c.ClientApp)
            .WithMany(ct => ct.Contatos)
            .HasForeignKey(Ic => Ic.IdClient);
    }

    }
}