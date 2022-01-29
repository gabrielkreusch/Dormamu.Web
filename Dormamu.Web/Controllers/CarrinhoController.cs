using Dormamu.Web.Models;
using Dormamu.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class CarrinhoController : BaseController
    {
        private readonly Contexto _contexto;

        public CarrinhoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            long? usuario = PessoaConectada();
            if (usuario != null)
            {
                long carrinhoID = (from carinho in _contexto.Carrinhos
                                   where carinho.PessoaID == usuario
                                   select carinho.ID)
                                        .FirstOrDefault();
                List<ItemCarrinho> itens = await (from item in _contexto.ItensCarrinhos
                                                  where item.CarrinhoID == carrinhoID
                                                  select item)
                                                    .Include(item => item.Produto)
                                                    .ToListAsync();

                return View(itens);
            }
            else
            {
                return View(null);
            }
        }

        private async Task CadastrarCarrinho(Carrinho carrinho)
        {
            _contexto.Carrinhos.Add(carrinho);
            await _contexto.SaveChangesAsync();
        }

        private async Task AlterarCarrinho(Carrinho carrinho)
        {
            _contexto.Update(carrinho);
            await _contexto.SaveChangesAsync();
        }

        private async Task ExcluirCarrinho(Carrinho carrinho)
        {
            _contexto.Remove(carrinho);
            await _contexto.SaveChangesAsync();
        }

        public IActionResult AdicionarItemCarrinho(long? produtoID, int quantidade = 1)
        {
            long? usuario = PessoaConectada();
            if (usuario != null && produtoID != null)
            {
                Carrinho carrinho = _contexto.Carrinhos
                    .Include(carrinho => carrinho.ItensCarrinho)
                    .FirstOrDefault(carrinho => carrinho.PessoaID == usuario);
                if (carrinho == null)
                {
                    CadastrarCarrinho(carrinho = new Carrinho()
                    {
                        PessoaID = (long)usuario,
                    }).Wait();
                }

                if (!carrinho.ItensCarrinho.Any(item => item.ProdutoID == produtoID))
                {
                    Produto produto = _contexto.Produtos.Find(produtoID);
                    CadastrarItemCarrinho(new ItemCarrinho()
                    {
                        Produto = produto,
                        Quantidade = quantidade,
                        Carrinho = carrinho
                    }).Wait();

                    return new JsonResult(new NotificationObject
                    {
                        Message = "Produto adicionado ao carrinho",
                        Title = "Sucesso",
                        Type = NotificationType.Success
                    });
                }
                else
                {
                    return new JsonResult(new NotificationObject
                    {
                        Message = "Você já adicionou esse produto ao carrinho",
                        Title = "Oops",
                        Type = NotificationType.Warning
                    });
                }
            }
            return new JsonResult(new NotificationObject
            {
                Message = "É necessário estar logado para adicionar itens ao carrinho",
                Title = "Oops",
                Type = NotificationType.Error
            });
        }

        private async Task CadastrarItemCarrinho(ItemCarrinho item)
        {
            _contexto.ItensCarrinhos.Add(item);
            await _contexto.SaveChangesAsync();
        }

        [HttpGet]
        public IActionResult LimparCarrinho(long? id, Carrinho carrinho)
        {
            if (id != null)
            {
                ExcluirCarrinho(carrinho).Wait();

                // Verificar se depois de excluir os parametros do carrinho se mantem
                carrinho.ItensCarrinho = null;
                CadastrarCarrinho(carrinho).Wait();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}