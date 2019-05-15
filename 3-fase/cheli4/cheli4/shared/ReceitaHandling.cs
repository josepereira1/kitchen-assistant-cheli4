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


       
    }
}
