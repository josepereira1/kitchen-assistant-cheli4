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
        //public Receita receita;

        //private Thread t;
        //private bool running;

        public RealizarReceitaViewController(DataBaseContext context)
        {
            this.receitaHandling = new ReceitaHandling(context);
            this.rec = new Reconhecimento();

            /* this.t = new Thread(new ThreadStart(run));
             this.running = true;
             */
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
            
            //startAssistente();
            return View(receita);           
        }












        public IActionResult assistente()
        {
            rec.Speak("Hello asshole!");
            return RedirectToAction("realizarReceita", "RealizarReceitaView");
        }



















        /*
        public void startAssistente()
        {
            if (t.IsAlive) {
                running = false;
                t.Join();
            }
            running = true;
            t = new Thread(new ThreadStart(run));
            t.Start();
        }


        public void run()
        {
            while(running)
            {
                String str = rec.Listen();

                switch (str) {

                    case "go next":
                        TempData["realizar_receita_passo"] = (int)TempData["realizar_receita_passo"] + 1;
                        break;

                    default:
                        break;
                }

            }
        }
        */
    }
}
