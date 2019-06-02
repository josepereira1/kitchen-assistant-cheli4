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

                if (expressoes.Count != 0)
                {
                    rec.Speak("From the following expressions point me the number which you did not understand.");

                    int n_expressao = 0;
                    foreach (Expressao exp in expressoes)
                    {
                        rec.Speak(n_expressao + " - " + exp.expressao);
                        n_expressao++;
                    }

                    /** Número da expressão indicado pelo utilizador */
                    int n = -1;

                    try
                    {
                        n = Int32.Parse(rec.Listen());
                        if (n < 0 || n > n_expressao) throw new Exception();

                    }
                    catch (Exception e)
                    {
                        rec.Speak("The number you said is invalid!");
                        return View(receita);
                    }

                    rec.Speak(expressoes[n].descricao);
                } 

                else
                {
                    rec.Speak("There are no expressions for this step!");
                }
            }

            /** caso tenha passo para ditar corre a Thread para o passo ser ditado 
                ao mesmo tempo que a página do novo passo é apresentada 
            */
            if (t != null) t.Start(); 
            return View(receita);           
        }

        public IActionResult assistente()
        {
            try
            {
                rec.Speak("Hi, tell me!");
                String text = rec.Listen();
               
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