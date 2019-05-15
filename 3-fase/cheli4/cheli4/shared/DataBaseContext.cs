using cheli4.Models.Comercial;
using cheli4.Models.RecursosHumanos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.shared
{
    public class DataBaseContext : DbContext
    {
        //  COMERCIAL

        public DbSet<Expressao> expressoes { set; get; }

        public DbSet<Ingrediente> ingredientes { set; get; }

        public DbSet<Passo> passos { set; get; }

        public DbSet<Receita> receitas { set; get; }

        public DbSet<ReceitaIngrediente> receitasIngredientes { set; get; }

        public DbSet<ReceitaPasso> receitasPassos { set; get; }


        //  RECURSOS HUMANOS

        public DbSet<Agenda> agendas { set; get; }

        public DbSet<Cliente> clientes { set; get; }

        public DbSet<ClienteReceita> clientesReceitas { set; get; }

        public DbSet<Quiz> quiz { set; get; }

        public DbSet<Resposta> respostas { set; get; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceitaIngrediente>()
                .HasKey(rc => new { rc.FK_id_ingrediente, rc.FK_id_receita });

            modelBuilder.Entity<ReceitaPasso>()
                .HasKey(rp => new { rp.FK_id_receita, rp.FK_id_passo });

            modelBuilder.Entity<Agenda>()
                .HasKey(a => new { a.FK_id_receita, a.FK_username_cliente });

            modelBuilder.Entity<ClienteReceita>()
                .HasKey(cr => new { cr.FK_username_cliente, cr.FK_id_receita });

            modelBuilder.Entity<Resposta>()
                .HasKey(r => new { r.FK_id_receita, r.FK_id_pergunta, r.data });

            // Recursos Humanos -----------------------------------------

            modelBuilder.Entity<ClienteReceita>()
                .HasOne(cr => cr.cliente)
                .WithMany(c => c.ClienteReceitas)
                .HasForeignKey(cr => cr.FK_username_cliente);

            modelBuilder.Entity<ClienteReceita>()
               .HasOne(cr => cr.receita)
               .WithMany(r => r.ClienteReceitas)
               .HasForeignKey(cr => cr.FK_id_receita);

            modelBuilder.Entity<Agenda>()
                .HasOne(a => a.cliente)
                .WithMany(c => c.agenda)
                .HasForeignKey(a => a.FK_username_cliente);

            modelBuilder.Entity<Agenda>()
               .HasOne(a => a.receita)
               .WithMany(r => r.agenda)
               .HasForeignKey(a => a.FK_id_receita);

            //TODO falta "ensinar" a tri-relação resposta (qd começarmos a fazer o quiz metemos) 

            // COMERCIAL -----------------------------------------------

            modelBuilder.Entity<ReceitaIngrediente>()
                .HasOne(ri => ri.receita)
                .WithMany(r => r.receitasIngredientes)
                .HasForeignKey(ri => ri.FK_id_receita);

            modelBuilder.Entity<ReceitaIngrediente>()
                .HasOne(ri => ri.ingrediente)
                .WithMany(i => i.receitasIngredientes)
                .HasForeignKey(ri => ri.FK_id_ingrediente);

            modelBuilder.Entity<ReceitaPasso>()
                .HasOne(rp => rp.receita)
                .WithMany(r => r.receitasPassos)
                .HasForeignKey(ri => ri.FK_id_receita);

            modelBuilder.Entity<ReceitaPasso>()
                .HasOne(rp => rp.passo)
                .WithMany(p => p.receitasPassos)
                .HasForeignKey(rp => rp.FK_id_passo);
        }
    }
}
