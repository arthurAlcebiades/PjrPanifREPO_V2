using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPaniMVCv2.Models;

namespace PrjPaniMVCv2.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly PaniContext _context;
        public MotoristaController(PaniContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            var motoristas = await _context.Motoristas.OrderBy(x => x.NomeMotorista).AsNoTracking().ToListAsync();
            return View(motoristas);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue)
            {
                var motorista = await _context.Motoristas.FindAsync(id);
                if (motorista == null)
                {
                    return NotFound();
                }
                return View(motorista);
            }
            return View(new MotoristaModel());
        }

        private bool MotoristaExiste(int id)
        {
        return _context.Motoristas.Any(x => x.IdMotorista == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] MotoristaModel motorista)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (MotoristaExiste(id.Value))
                    {
                        _context.Motoristas.Update(motorista);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Motorista alterado com sucesso! ;)");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar motorista.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Motorista não encontrado. X(", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Motoristas.Add(motorista);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Motorista cadastrado com sucesso. :)");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar motorista. X(", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(motorista);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Motorista não informado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Motorista não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(motorista);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista != null)
            {
                _context.Motoristas.Remove(motorista);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Motorista excluído com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o motorista.", TipoMensagem.Erro);
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Motorista não encontrado.", TipoMensagem.Erro);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

