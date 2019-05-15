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
        private readonly DataBaseContext _context;

        public ReceitaHandling(DataBaseContext context)
        {
            _context = context;
        }

        public Receita[] getReceitas()
        {
            return this._context.receitas.ToArray();
        }

        public Ingrediente[] getIngredientes()
        {
            return this._context.ingredientes.ToArray();
        }

        public ReceitaIngrediente[] getReceitasIngredientes()
        {
            return this._context.receitasIngredientes.ToArray();
        }

        public Receita getReceita(int id)
        {
            Receita receita = this._context.receitas.Find(id);
            if (receita == null) return null; // para não dar erro nas proximas linhas

            receita.receitasPassos = this._context.receitasPassos.Where(rp => rp.FK_id_receita == receita.id).ToList();
            foreach(ReceitaPasso p in receita.receitasPassos)
            {
                p.passo = this._context.passos.Find(p.FK_id_passo);
            }

            return receita;
        }

        /// <summary>
        /// Devolve os ingredientes de uma receita.
        /// </summary>
        /// <param name="nome">nome da receita</param>
        /// <returns>Retorna os ingredientes de uma receita</returns>
        public Ingrediente[] getReceita(string nome)
        {
            var receitas = _context.receitas.Where(r => r.nome == nome).ToArray();

            var receitasIngredientes = _context.receitasIngredientes.Where(ri => ri.FK_id_receita == receitas[0].id);

            List<Ingrediente> ingredientes = new List<Ingrediente>();

            foreach(ReceitaIngrediente ri in receitasIngredientes)
            {
                ingredientes.Add(_context.ingredientes.Find(ri.FK_id_ingrediente));
            }
            return ingredientes.ToArray();
        }


       
    }
}
