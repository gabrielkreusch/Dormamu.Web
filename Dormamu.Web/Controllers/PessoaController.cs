using Dormamu.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class PessoaController : BaseController
    {
        private readonly Contexto _contexto;

        public PessoaController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Pessoas.ToListAsync());
        }

        [HttpGet]
        public IActionResult CadastrarPessoa()
        {
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
                return View(pessoa);
            }
        }

        [HttpGet]
        public IActionResult AlterarPessoa(long? id)
        {
            if (id != null)
            {
                Pessoa pessoa = _contexto.Pessoas.Find(id);
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AlterarPessoa(long? id, Pessoa pessoa)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _contexto.Update(pessoa);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(pessoa);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult ExcluirPessoa(long? id)
        {
            if (id != null)
            {
                Pessoa pessoa = _contexto.Pessoas.Find(id);
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirPessoa(long? id, Pessoa pessoa)
        {
            if (id != null)
            {
                _contexto.Remove(pessoa);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
