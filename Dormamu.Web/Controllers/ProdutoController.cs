using Dormamu.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly Contexto _contexto;

        public ProdutoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Produtos.ToListAsync());
        }

        [HttpGet]
        public IActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(produto);
            }
        }

        [HttpGet]
        public IActionResult AlterarProduto(long? id)
        {
            if (id != null)
            {
                Produto produto = _contexto.Produtos.Find(id);
                return View(produto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AlterarProduto(long? id, Produto produto)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _contexto.Update(produto);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(produto);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult ExcluirProduto(long? id)
        {
            if (id != null)
            {
                Produto produto = _contexto.Produtos.Find(id);
                return View(produto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirProduto(long? id, Produto produto)
        {
            if (id != null)
            {
                _contexto.Remove(produto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult DetalhesProduto(long? id)
        {
            if (id != null)
            {
                Produto produto = _contexto.Produtos.Find(id);
                return View(produto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> CatalogoProdutos()
        {
            return View(await _contexto.Produtos.ToListAsync());
        }
    }
}
