using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPaniMVCv2.Models;

namespace PrjPaniMVCv2.Controllers
{
    public class RotaController : Controller
    {
        private readonly PaniContext _context;
        public RotaController(PaniContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            var rotas = await _context.Rotas.OrderBy(x => x.ApelidoRota).AsNoTracking().ToListAsync();
            return View(rotas);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue)
            {
                var rota = await _context.Rotas.FindAsync(id);
                if (rota == null)
                {
                    return NotFound();
                }
                return View(rota);
            }
            return View(new RotaModel());
        }

        private bool RotaExiste(int id)
        {
            return _context.Rotas.Any(x => x.IdRota == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] RotaModel rota)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (RotaExiste(id.Value))
                    {
                        _context.Rotas.Update(rota);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Rota alterada com sucesso! ;)");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar rota.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Rota não encontrada. X(", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Rotas.Add(rota);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Rota cadastrada com sucesso. :)");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar rota. X(", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(rota);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Rota não informada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var rota = await _context.Rotas.FindAsync(id);
            if (rota == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Rota não encontrada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(rota);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            if (rota != null)
            {
                _context.Rotas.Remove(rota);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Rota excluída com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir a rota.", TipoMensagem.Erro);
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Rota não encontrada.", TipoMensagem.Erro);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
