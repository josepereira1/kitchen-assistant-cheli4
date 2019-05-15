using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cheli4.Models;
using cheli4.Models.Comercial;

namespace cheli4.shared
{
    public class ReceitaHandling
    {
        private readonly ReceitaContext _context;

        public ReceitaHandling(ReceitaContext context)
        {
            _context = context;
        }

        public Receita[] getReceitas()
        {
            return _context.receitas.ToArray();
        }

        public Receita getReceita(int id)
        {
            return _context.receitas.Find(id);        
        }

        public Ingrediente[] getIngredientes()
        {
            return _context.ingredientes.ToArray();
        }

        public Ingrediente getIngrediente(int id)
        {
            return _context.ingredientes.Find(id);
        }

        public Passo[] getPassos()
        {
            return _context.passos.ToArray();
        }

        public Passo getPasso(int id)
        {
            return _context.passos.Find(id);
        }


       
    }
}
