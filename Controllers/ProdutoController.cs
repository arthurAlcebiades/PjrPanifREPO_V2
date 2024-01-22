using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjPaniMVCv2.Models;

namespace PrjPaniMVCv2.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly PaniContext _context;

        public ProdutoController(PaniContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.OrderBy(x => x.NomeProduto).AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            /*var produtos = _context.Produtos.OrderBy(x => x.NomeProduto).AsNoTracking().ToList();
            var produtosSelectList = new SelectList(produtos,
                nameof(ProdutoModel.IdProduto), nameof(ProdutoModel.NomeProduto));
            ViewBag.Produtos = produtosSelectList; 
            */

            if (id.HasValue)
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }
                return View(produto);
            }
            return View(new ProdutoModel());
        }

        private bool ProdutoExiste(int id)
        {
            return _context.Produtos.Any(x => x.IdProduto == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (ProdutoExiste(id.Value))
                    {
                        _context.Produtos.Update(produto);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Produto alterado com sucesso! ;)");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar produto.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Produto não encontrado. X(", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Produtos.Add(produto);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Produto cadastrado com sucesso. :)");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar produto. X(", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(produto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Produto não informado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Produto não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Produto excluído com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o produto.", TipoMensagem.Erro);
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Produto não encontrado.", TipoMensagem.Erro);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
