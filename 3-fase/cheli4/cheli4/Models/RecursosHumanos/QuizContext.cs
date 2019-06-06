using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Models.RecursosHumanos
{
    public class QuizContext : DbContext
    {
        public DbSet<Quiz> quiz { get; set; } // tabela Quiz
        public DbSet<Resposta> respostas { get; set; } // tabela Resposta

        public QuizContext(DbContextOptions<QuizContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // TODO caso façamos o QUIZ completar este método e tb as classes Receita e Cliente
        }
    }
}
