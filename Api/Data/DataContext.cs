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
        public DbSet<Peca> peca { get; set; }
        public DbSet<VendaPeca> vendaPecas { get; set; }
        public DbSet<ItemPeca> itemPeca { get; set; }
        public DbSet<Servicos> servicos { get; set; }
        public DbSet<Chamados> chamados { get; set; }
                
   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Contatos>()
            .HasOne(c => c.ClientApp)
            .WithMany(ct => ct.Contatos)
            .HasForeignKey(Ic => Ic.IdClient)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<VendaPeca>()
            .HasOne(vp => vp.Cliente)
            .WithMany()
            .HasForeignKey(vp => vp.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ItemPeca>()
            .HasOne(ip => ip.VendaPeca)
            .WithMany(vp => vp.ItemPeca)
            .HasForeignKey(vp => vp.IdVendaPeca)
            .OnDelete(DeleteBehavior.Cascade);
             

        builder.Entity<Servicos>()
            .HasOne(s => s.Cliente)
            .WithMany()
            .HasForeignKey(s => s.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Servicos>()
            .HasOne(s => s.Peca)
            .WithMany()
            .HasForeignKey(s => s.IdPeca);

        builder.Entity<Chamados>()
            .HasOne(s => s.Cliente)
            .WithMany()
            .HasForeignKey(s => s.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);
    }

    }
}