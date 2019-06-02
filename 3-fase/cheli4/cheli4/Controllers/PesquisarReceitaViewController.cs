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
        public IActionResult pesquisarReceitaPorNome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult pesquisarReceitaPorNome(string nome)
        {
            if (ModelState.IsValid) {
                Receita r = this.receitaHandling.getReceita(nome);

                if (r != null) {
                    //TempData["Sucesso"] = "Encontrou receita!";
                    ModelState.Clear();
                    TempData["PRN"] = nome;
                    return RedirectToAction("getReceitaAndIngredientes", "PreReceitaView");
                } else{
                    TempData["Fail"] = "Não existe receita com este nome! Tente novamente";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult pesquisarReceitaPorFiltros()
        {
            return View();
        }

        [HttpPost]
        public IActionResult pesquisarReceitaPorFiltros(string[] YourCheckboxes)
        {
            if (YourCheckboxes.Count() != 0)
            {
                List<Receita> receitas = new List<Receita>();
                
                foreach (string tipo in YourCheckboxes)
                {
                    List<Receita> receitasDesteTipo = this.receitaHandling.getReceitasPorTipo(tipo);
                    if (receitasDesteTipo != null && receitasDesteTipo.Count != 0) foreach (var r in receitasDesteTipo) if (!receitas.Contains(r)) receitas.Add(r);
                }

                if(receitas.Count == 0) // CASO NÃO TENHO SIDO FILTRADAS QUAISQUER RECEITAS
                {
                    TempData["Fail"] = "No results to display";
                    return View();
                }
                else
                {
                    TempData["Filtrar"] = "Sim";
                    return View(receitas);
                }
            }
            else    //  CASO O CLIENTE NÃO TENHA SELECIONADO NENHUM FILTRO
            {
                TempData["Fail"] = "No results to display";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Contactos()
        {
            return View();
        }
    }
}
