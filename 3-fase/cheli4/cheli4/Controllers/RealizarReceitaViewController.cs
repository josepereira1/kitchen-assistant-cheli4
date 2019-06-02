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
        private String passo;

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

            Thread t = null;

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
                this.passo = receita.receitasPassos.ToList()[n_passo].passo.descricao;
                t = new Thread(run);
                TempData["realizar_receita_passo"] = n_passo;
            }

            
            if (TempData["expressions"] != null) // EXPRESIONS
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

            if (t != null) t.Start();
            return View(receita);           
        }

        public IActionResult assistente()
        {
            try
            {
                String text;
                rec.Speak("Hi, tell me!");
                try
                {
                    text = rec.Listen();
                }
                catch (Exception e)
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
                else if (type == 4)
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

            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return RedirectToAction("realizarReceita", "RealizarReceitaView");
            }
        }

        private void run()
        {
            rec.Speak(passo);
        }
    }
}