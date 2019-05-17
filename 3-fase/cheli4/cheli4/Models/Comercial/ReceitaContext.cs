using cheli4.Models.RecursosHumanos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.Comercial
{
    public class ReceitaContext : DbContext 
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ClienteReceita>();
            modelBuilder.Ignore<Agenda>();
        }

        public DbSet<Receita> receitas { get; set; }
    }
}
