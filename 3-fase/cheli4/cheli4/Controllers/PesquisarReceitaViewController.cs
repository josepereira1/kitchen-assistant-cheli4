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
    public class PesquisarReceitaViewController : Controller
    {
        private ReceitaHandling receitaHandling;

        public PesquisarReceitaViewController(DataBaseContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
        }

        [HttpGet]
        public IActionResult pesquisarReceita()
        {
            return View();
        }

        [HttpPost]
        public IActionResult pesquisarReceita(string nome)
        {
            if (ModelState.IsValid) {
                Receita r = this.receitaHandling.getReceita(nome);

                if (r != null) {
                    //TempData["Sucesso"] = "Encontrou receita!";
                    ModelState.Clear();
                    TempData["pre_receita_nome"] = nome;
                    return RedirectToAction("getReceitaAndIngredientes", "PreReceitaView");
                } else{
                    TempData["Fail"] = "Não existe receita com este nome! Tente novamente";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult pesquisarReceitaPorFiltro()
        {
            return View();
        }


    }
}
