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
    public class RealizarReceitaViewController : Controller
    {
        private ReceitaHandling receitaHandling;
        
        public RealizarReceitaViewController(DataBaseContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
        }

        public IActionResult realizarReceita_ant()
        {
            TempData["realizar_receita_passo"] = (int)TempData["realizar_receita_passo"] - 1;
            return RedirectToAction("realizarReceita", "RealizarReceitaView");
        }

        public IActionResult realizarReceita_prox()
        {
            TempData["realizar_receita_passo"] = (int)TempData["realizar_receita_passo"] + 1;
            return RedirectToAction("realizarReceita", "RealizarReceitaView");
        }

        public IActionResult realizarReceita()
        {
            int id = (int)TempData["realizar_receita_id"];
            Receita receita = this.receitaHandling.getReceita(id);

            if (receita == null)
            {
                TempData["realizar_receita_fail"] = "id da receita não existe na base de dados";
                return View();
            }

            else
            {
                TempData["realizar_receita_id"] = id;
                return View(receita);
            }
        } 
    }
}
