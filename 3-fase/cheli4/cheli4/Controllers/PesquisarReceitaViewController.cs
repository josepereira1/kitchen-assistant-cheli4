using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cheli4.Models;
using cheli4.shared;
using cheli4.Models.Comercial;

namespace cheli4.Controllers
{
    [Route("[controller]/[action]")]
    public class PesquisarReceitaViewController : Controller
    {
        private ReceitaHandling receitaHandling;

        public PesquisarReceitaViewController(ReceitaContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
        }

        public IActionResult getReceitas()
        {
            Receita[] receitas = this.receitaHandling.getReceitas();
            return View(receitas);
        }

        public IActionResult getReceita()
        {
            Receita receita = this.receitaHandling.getReceita(1);
            return View(receita);
        }

        


        /*[HttpPost]
        public IActionResult pesquisarReceita([Bind] string nome)
        {
            if (ModelState.IsValid) {
                Receita receita = this.receitaHandling.getReceita(nome);
                if (receita != null) {
                    TempData["Sucesso"] = "Encontrou receita!";
                    ModelState.Clear();
                    return View(receita);
                } else{
                    TempData["Fail"] = "Não existe receita com este id!";
                }
            }
            return View();
        }*/
    }
}
