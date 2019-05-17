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
            string nome = TempData["pre_receita_nome"].ToString();
            Receita r = this.receitaHandling.getReceitaAndIngredientes(nome);
            return View(r);
        }
    }
}
