using Dormamu.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class ItemCarrinhoController : Controller
    {
        private readonly Contexto _contexto;

        public ItemCarrinhoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirItemCarrinho(long? id)
        {
            if (id != null)
            {
                ItemCarrinho item = _contexto.ItensCarrinhos.Find(id);
                if (item != null)
                {
                    _contexto.Remove(item);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction("Index", "Carrinho");
                }
            }
            else
            {

            }

            return View();
        }
    }
}
