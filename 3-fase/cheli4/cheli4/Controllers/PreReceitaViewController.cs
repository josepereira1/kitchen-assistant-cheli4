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
        public IActionResult getReceitaAndIngredientes()
        {
            string nome = TempData["PRN"].ToString();
            Receita r = this.receitaHandling.getReceitaAndIngredientes(nome);
            TempData["PRN"] = nome; //  isto é para caso a pessoa atualize a página!!!
            return View(r);
        }

        [HttpPost]
        public IActionResult getReceitaAndIngredientes(string nome)
        {
            Receita r = this.receitaHandling.getReceitaAndIngredientes(nome);
            TempData["PRN"] = nome; //  isto é para caso a pessoa atualize a página!!!
            if (r != null) return View(r);
            else return null;
        }
    }
}
