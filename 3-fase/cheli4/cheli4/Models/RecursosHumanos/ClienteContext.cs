using cheli4.Models.Comercial;
using Microsoft.EntityFrameworkCore;

namespace cheli4.Models.RecursosHumanos
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; } // tabela Cliente 
        
        // relcações de N para N
        public DbSet<ClienteReceita> clienteReceitas { get; set; } // tabela ClienteReceita
        public DbSet<Agenda> agenda { get; set; } // tabela Agenda

        public ClienteContext(DbContextOptions<ClienteContext> options)
           : base(options)
        {
     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            // ClienteReceita -------------------------------------------------------

            modelBuilder.Entity<ClienteReceita>()
                .HasKey(cr => new { cr.FK_username_cliente, cr.FK_id_receita });

            modelBuilder.Entity<ClienteReceita>()
                .HasOne(cr => cr.cliente)
                .WithMany(c => c.receitas)
                .HasForeignKey(cr => cr.FK_username_cliente);

            modelBuilder.Entity<ClienteReceita>()
               .HasOne(cr => cr.receita)
               .WithMany(r => r.clientes)
               .HasForeignKey(cr => cr.FK_id_receita);


            // Agenda ---------------------------------------------------------------

            modelBuilder.Entity<Agenda>()
                .HasKey(a => new { a.FK_username_cliente, a.FK_id_receita });

            modelBuilder.Entity<Agenda>()
                .HasOne(a => a.cliente)
                .WithMany(c => c.agenda)
                .HasForeignKey(a => a.FK_username_cliente);

            modelBuilder.Entity<Agenda>()
               .HasOne(a => a.receita)
               .WithMany(r => r.agenda)
               .HasForeignKey(a => a.FK_id_receita);
               */

            modelBuilder.Ignore<Agenda>();
            modelBuilder.Ignore<ClienteReceita>();
        }
    }
}
