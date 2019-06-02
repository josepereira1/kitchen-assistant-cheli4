using cheli4.Models.Comercial;
using cheli4.shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace cheli4.Controllers
{
    [Route("[controller]/[action]")]
    public class RealizarReceitaViewController : Controller
    {
        private ReceitaHandling receitaHandling;
        private Reconhecimento rec;
        private String str;
        private List<Expressao> expressoes;

        public RealizarReceitaViewController(DataBaseContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
            this.rec = null;
            this.str = null;
            this.expressoes = null;
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

            else if(TempData["ditar_passo"] != null) //  REPEAT, NEXT ou BACK
            {
                if (rec == null) this.rec = new Reconhecimento();

                int n_passo = (int)TempData["realizar_receita_passo"];
                this.str = receita.receitasPassos.ToList()[n_passo].passo.descricao;
                new Thread(run).Start(); // diz o próximo passo
                TempData["realizar_receita_passo"] = n_passo;
            }

            
            else if (TempData["expressions"] != null) // EXPRESIONS
            {
                if (rec == null) this.rec = new Reconhecimento();

                int n_passo = (int)TempData["realizar_receita_passo"];
                this.expressoes = receita.receitasPassos.ToList()[n_passo].passo.expressoes.ToList();
                TempData["realizar_receita_passo"] = n_passo;

                new Thread(run2).Start();
               
            }

            return View(receita);           
        }

        public IActionResult assistente()
        {
            if (rec == null) this.rec = new Reconhecimento();

            try
            {
                rec.Speak("Hi, tell me.");
                String text = rec.Listen();
               
                int type = rec.commandType(text);
                if (type == 0) // NEXT
                {
                    TempData["ditar_passo"] = true;
                    return RedirectToAction("realizarReceita_prox", "RealizarReceitaView");
                }
                else if (type == 1) // BACK
                {
                    TempData["ditar_passo"] = true;
                    return RedirectToAction("realizarReceita_ant", "RealizarReceitaView");
                }
                else if (type == 2) // HELP
                {
                    TempData["popup"] = true;
                    return RedirectToAction("realizarReceita", "RealizarReceitaView");
                }
                else if (type == 3) // REPEAT
                {
                    TempData["ditar_passo"] = true;
                    return RedirectToAction("realizarReceita", "RealizarReceitaView");
                }
                else if (type == 4) // EXPRESSIONS
                {
                    TempData["expressions"] = true;
                    return RedirectToAction("realizarReceita", "RealizarReceitaView");
                }
                else // INSUCESSO AO PERCEBER COMANDO
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
            rec.Speak(str);
        }

        public void run2()
        {
            if (expressoes.Count != 0) { 

                rec.Speak("From the following expressions point me the number which you did not understand.");

                int n_expressao = 0;
                foreach (Expressao exp in expressoes)
                {
                    rec.Speak(n_expressao + ". " + exp.expressao);
                    n_expressao++;
                }

                /** Número da expressão indicado pelo utilizador */
                int n = -1;

                rec.Speak("Tell me the number now!");
                String str = rec.Listen();

                System.Diagnostics.Debug.WriteLine("=>>>>>>>>>>>>>>>>>>>>>>>>>" + str);

                try
                {
                    if (str.Contains("0") || str.Contains("zoo") || str.Contains("zeal") || str.Contains("xur")) n = 0;
                    else if (str.Contains("1")) n = 1;
                    else if (str.Contains("2") || str.Contains("too") || str.Contains("to")) n = 2;
                    else if (str.Contains("3") || str.Contains("free")) n = 3;
                    else if (str.Contains("4")) n = 4;
                    else if (str.Contains("5")) n = 5;
                    else if (str.Contains("6")) n = 6;
                    else if (str.Contains("7")) n = 7;
                    else if (str.Contains("8") || str.Contains("hey")) n = 8;
                    else if (str.Contains("9")) n = 9;
                    else n = Int32.Parse(str);

                    if (n < 0 || n > expressoes.Count -1) { throw new Exception(); }

                    } catch (Exception e)
                {
                    rec.Speak("The number you said is invalid!");
                }

                //rec.Speak(expressoes[n].descricao);
            }

            else
            {
                rec.Speak("There are no expressions for this step!");
            }

        }
    }
}