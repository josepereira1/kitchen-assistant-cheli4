using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using cheli4.Models;
using cheli4.Models.Comercial;
using cheli4.Models.RecursosHumanos;
using Microsoft.EntityFrameworkCore;

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
            foreach (ReceitaPasso rp in receita.receitasPassos)
            {
                rp.passo = this._context.passos.Find(rp.FK_id_passo); // vai buscar o passo
                rp.passo.expressoes = this._context.expressoes.Where(expr => expr.FK_id_passo == rp.FK_id_passo).ToList();
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

        /*public void setClassificacao(int classificacao, int receita_id, string username)
        {
            List<ClienteReceita> list = this._context.clientesReceitas.Where(elem => elem.FK_username_cliente == username && elem.FK_id_receita == receita_id).ToList();
            ClienteReceita cr = null;

            if (list.Count() == 0) {
                cr = new ClienteReceita { FK_username_cliente = username, FK_id_receita = receita_id, n_realizada = 1, ultima_nota = classificacao };
                this._context.clientesReceitas.Add(cr);
            } else
            {
                cr = list.First();
                cr.ultima_nota = classificacao;
                cr.n_realizada++;
                this._context.Entry(cr).State = EntityState.Modified;
            }

            
            this._context.SaveChanges();
        }*/
    }
}
