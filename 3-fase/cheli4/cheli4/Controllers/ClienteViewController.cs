using cheli4.Models;
using cheli4.Models.RecursosHumanos;
using cheli4.shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cheli4.Controllers
{
    [Route("[controller]/[action]")]
    public class ClienteViewController : Controller
    {
        private ClienteHandling clienteHandling;

        public ClienteViewController(DataBaseContext context)
        {
            this.clienteHandling = new ClienteHandling(context);
        }

        // PARA DEBUG ---------------------------------------------------

        [HttpGet]
        public IActionResult getClientes()
        {
            Cliente[] people = this.clienteHandling.getClientes();
            return View(people);
        }

        // REGISTAR CLIENTE ---------------------------------------------------

        [HttpGet]
        public IActionResult registar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult registar([Bind] Cliente c)
        {
            ModelState.Remove("apagado");

            if (ModelState.IsValid)
            {
                c.apagado = false;
                bool RegistrationStatus = this.clienteHandling.addCliente(c);

                if (RegistrationStatus)
                {
                    ModelState.Clear();
                    TempData["registar_Success"] = "Registration Successful!";
                }
                else
                {
                    TempData["registar_Fail"] = "This useranme already exists. Registration Failed.";
                }
            }

            return View();
        }

        // LOGIN ---------------------------------------------------------

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login([Bind] Cliente cliente)
        {
            /** O método IsValid() verfica se o objeto cliente tem todos os campos [Required] preenchidos.
             * Uma vez que para o login apenas precisamos dos campos: username e password mas no entanto existem
             * mais campos obrigatórios ([Required]) é necessário não contar com esses campos, ou seja remove-los 
             * do MovelState.
             */
            ModelState.Remove("nome");
            ModelState.Remove("email");
            ModelState.Remove("apagado");

            if (ModelState.IsValid)
            {
                TempData["username"] = cliente.username;
                bool loginStatus = this.clienteHandling.validateCliente(cliente);

                if (loginStatus)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, cliente.username)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    TempData["login_Success"] = "Login successful!";
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["login_Fail"] = "Login Failed. Please enter correct credentials";
                }
            }
            return View();
        }

        // LOGOUT ---------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Codigos()
        {
            List<Codigo> codigos = this.clienteHandling.getCodigosCliente("jose");
            if (codigos.Count == 0 || codigos == null)
            {
                TempData["Fail"] = "Do not have codes!";
                return View();
            }
            else {
                return View(codigos);
            }
            
        }
    }
}
