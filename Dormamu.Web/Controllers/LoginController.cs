using Dormamu.Web.Models;
using Dormamu.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly Contexto _contexto;

        public LoginController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return new JsonResult(new NotificationObject()
                {
                    Title = "Atenção",
                    Message = "Usuário já logado.",
                    Type = NotificationType.Warning
                });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(pessoa);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Login(string usuario, string senha, bool manterConectado)
        {
            Pessoa pessoa = _contexto.Pessoas.FirstOrDefault(pessoa => pessoa.CPFCNPJ == usuario || pessoa.Email == usuario);
            if (pessoa != null && pessoa.Senha == senha)
            {
                // FAZER COM SHA512
                //using (SHA512 sha512 = SHA512.Create())
                //{
                //    if (pessoa.Senha == sha512.ComputeHash())
                //}
                List<Claim> direitosAcesso = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, pessoa.ID.ToString()),
                    new Claim(ClaimTypes.Name, pessoa.Nome)
                };

                var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                var user = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(user,
                    new AuthenticationProperties
                    {
                        IsPersistent = manterConectado,
                        ExpiresUtc = DateTime.Now.AddHours(1)
                    });

                return RedirectToAction("Index", "Home");
            }
            return new JsonResult(new NotificationObject()
            {
                Title = "Usuário não encontrado!",
                Message = "Verifique as credenciais e tente novamente.",
                Type = NotificationType.Error
            });
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
