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

     
        }

        public DbSet<Receita> receitas {get;set;}
        public DbSet<Ingrediente> ingredientes { get; set; }
        public DbSet<Passo> passos { get; set; }
    }
}
