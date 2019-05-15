using cheli4.Models.Comercial;
using cheli4.shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Controllers
{
    [Route("[controller]/[action]")]
    public class PreReceitaViewController : Controller
    {
        private ReceitaHandling receitaHandling;

        public PreReceitaViewController(DataBaseContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
        }

        [HttpGet]
        public IActionResult getReceitas()
        {
            Receita[] receitas = this.receitaHandling.getReceitas();
            //Ingrediente[] ingredientes = this.receitaHandling.getReceita("Bacalhau");
            return View(receitas);
        }

        [HttpGet]
        public IActionResult getIngredientes()
        {
            Ingrediente[] ingredientes = this.receitaHandling.getIngredientes().ToArray();
            return View(ingredientes);
        }

        [HttpGet]
        public IActionResult getReceitasIngredientes()
        {
            ReceitaIngrediente[] receitasIngredientes = this.receitaHandling.getReceitasIngredientes();
            return View(receitasIngredientes);
        }




        /*
        [HttpGet]
        public IActionResult pesquisarReceita()
        {
            Receita receita = this.receitaHandling.getReceita("cona");
            return View(receita);
        }

        [HttpPost]
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
