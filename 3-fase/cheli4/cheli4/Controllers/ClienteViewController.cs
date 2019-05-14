using cheli4.Models;
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

        public ClienteViewController(ClienteContext context)
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
            if (ModelState.IsValid)
            {
                c.apagado = false;
                bool RegistrationStatus = this.clienteHandling.addCliente(c);

                if (RegistrationStatus)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                }
                else
                {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
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
            ModelState.Remove("nome");
            ModelState.Remove("email");

            if (ModelState.IsValid)
            {
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
                    TempData["Success"] = "Login successful!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Fail"] = "Login Failed. Please enter correct credentials";
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
    }
}
