using Dormamu.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly Contexto _contexto;

        public PedidoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            // ALTERAR PARA LISTAR APENAS AS COMPRAS DO USUÁRIO LOGADO
            return View(await _contexto.Pedidos.ToListAsync());
        }

        //public IActionResult CadastrarPedido()
        //{
        //    return view
        //}
    }
}
