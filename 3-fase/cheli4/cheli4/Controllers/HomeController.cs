using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false) return RedirectToAction("login", "ClienteView");
            else return RedirectToAction("pesquisarReceita", "PesquisarReceitaView");
        }
    }
}
