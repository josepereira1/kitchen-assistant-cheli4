using cheli4.Models.Comercial;
using cheli4.shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cheli4.Controllers
{
    [Route("[controller]/[action]")]
    public class RealizarReceitaViewController : Controller
    {
        private ReceitaHandling receitaHandling;
        private Reconhecimento rec;

        public RealizarReceitaViewController(DataBaseContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
            this.rec = new Reconhecimento();
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
            Receita receita = this.receitaHandling.getReceitaAndPassos(id);
            TempData["realizar_receita_id"] = id;

            if (receita == null)
            {
                TempData["realizar_receita_fail"] = "id da receita não existe na base de dados";
                return View();
            }

            if(TempData["ditar_passo"] != null) //  REPEAT, NEXT ou BACK
            {
                int n_passo = (int)TempData["realizar_receita_passo"];
                rec.Speak(receita.receitasPassos.ToList()[n_passo].passo.descricao);
                TempData["realizar_receita_passo"] = n_passo;
            }

            
            if (TempData["expressions"] != null) //  REPEAT, NEXT ou BACK
            {
                
                int n_passo = (int)TempData["realizar_receita_passo"];
                List<Expressao> expressoes = receita.receitasPassos.ToList()[n_passo].passo.expressoes.ToList();
                TempData["realizar_receita_passo"] = n_passo;

                if (expressoes.Count() == 0)
                {
                    rec.Speak("There are no expressions for this step!");
                    return View(receita);
                }

                int n_expressao = 0;

                rec.Speak("From the following expressions point me the number which you did not understand.");
                
                foreach (Expressao exp in expressoes)
                {
                    rec.Speak(n_expressao + " - " + exp.expressao);
                    n_expressao++;
                }
            }
            

            return View(receita);           
        }

        public IActionResult assistente()
        {
            rec.Speak("Hi, tell me!");
            String text;
            try
            {
                text = rec.Listen();
            }catch (Exception e)
            {
                rec.Speak("Could not understand, please try again!");
                return RedirectToAction("realizarReceita", "RealizarReceitaView");
            }
            int type = rec.commandType(text);
            if (type == 0)
            {
                TempData["ditar_passo"] = true;
                return RedirectToAction("realizarReceita_prox", "RealizarReceitaView");
            }
            else if (type == 1)
            {
                TempData["ditar_passo"] = true;
                return RedirectToAction("realizarReceita_ant", "RealizarReceitaView");
            }
            else if (type == 2)
            {
                TempData["popup"] = true;
                return RedirectToAction("realizarReceita", "RealizarReceitaView");
            }
            else if (type == 3)
            {
                TempData["ditar_passo"] = true;
                return RedirectToAction("realizarReceita", "RealizarReceitaView");
            }
            else if(type == 4)
            {
                TempData["expressions"] = true;
                return RedirectToAction("realizarReceita", "RealizarReceitaView");
            }
            else
            {
                rec.Speak("Could not understand, please try again!");
                return RedirectToAction("realizarReceita", "RealizarReceitaView");
            }
        }
    }
}
