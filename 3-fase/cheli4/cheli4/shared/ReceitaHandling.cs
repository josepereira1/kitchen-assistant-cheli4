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

        public Receita getReceitaAndPassos(int id)
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

        public Receita getReceita(int id)
        {
            return this._context.receitas.Find(id);
        }

        public Receita getReceita(string nome)
        {
            var receitas = this._context.receitas.Where(r => r.nome == nome);
            if (receitas.Count() == 0) return null;
            else return receitas.ToArray()[0];
        }


        public Receita getReceitaAndIngredientes(int id)
        {
            Receita receita = this._context.receitas.Find(id);

            if (receita == null) return null;

            receita.receitasIngredientes = this._context.receitasIngredientes.Where(ri => ri.FK_id_receita == receita.id).ToList();

            foreach (ReceitaIngrediente ri in receita.receitasIngredientes)
            {
                ri.ingrediente = this._context.ingredientes.Find(ri.FK_id_ingrediente);
            }

            return receita;
        }

        public List<Receita> getReceitasPorTipo(string tipo)
        {
            List<Receita> receitas = this._context.receitas.Where(r => r.tipo == tipo).ToList();

            if (receitas.Count == 0) return null;
            else return receitas;
        }

        public Receita getReceitaAndIngredientes(string nome)
        {
            List<Receita> receitas = this._context.receitas.Where(r => r.nome == nome).ToList();

            if (receitas.Count == 0) return null;

            Receita receita = receitas.First();

            if (receita != null)
            {
                receita.receitasIngredientes = this._context.receitasIngredientes.Where(ri => ri.FK_id_receita == receita.id).ToList();

                if (receita.receitasIngredientes != null)
                {
                    foreach (ReceitaIngrediente ri in receita.receitasIngredientes)
                    {
                        ri.ingrediente = this._context.ingredientes.Find(ri.FK_id_ingrediente);
                    }
                }
                return receita;
            }
            else
            {
                return null;
            }
        }
    }
}
