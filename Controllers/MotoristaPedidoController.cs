using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjPaniMVCv2.Models;

namespace PrjPaniMVCv2.Controllers
{
    public class MotoristaPedidoController : Controller
    {
        private readonly PaniContext _context;

        public MotoristaPedidoController(PaniContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index(int? ped)
        {
            if (ped.HasValue)
            {
                if (_context.Pedidos.Any(p => p.IdPedido == ped))
                {
                    var pedido = await _context.Pedidos
                        //.Include(p => p.Motorista)
                        .Include(p => p.MotoristaPedidos.OrderBy(i => i.Motoristas.NomeMotorista))
                        .ThenInclude(p => p.Motoristas)
                        .FirstOrDefaultAsync(p => p.IdPedido == ped);

                    ViewBag.Pedido = pedido;
                    return View(pedido.MotoristaPedidos);
                }
                TempData["mensagem"] = MensagemModel.Serializar("Pedido não encontrado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Pedido não informado.", TipoMensagem.Erro);
            return RedirectToAction("Index", "Cliente");
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? ped, int? med)
        {
            if (ped.HasValue)
            {
                if (_context.Pedidos.Any(p => p.IdPedido == ped))
                {
                    var motoristas = _context.Motoristas
                        .OrderBy(x => x.NomeMotorista)
                        .Select(p => new { p.IdMotorista, ApelidoRota = $"{p.NomeMotorista} ({p.ApelidoRota})" })
                        .AsNoTracking().ToList();
                    var motoristasSelectList = new SelectList(motoristas, "IdMotorista", "ApelidoRota");
                    ViewBag.Motoristas = motoristasSelectList;

                    if (med.HasValue && MotoristaExiste(ped.Value, med.Value))
                    {
                        var motoristaPedido = await _context.MotoristasPedidos
                            .Include(i => i.Motoristas)
                            .FirstOrDefaultAsync(i => i.IdPedido == ped && i.IdMotorista == med);
                        return View(motoristas);
                    }
                    else
                    {
                        return View(new MotoristaPedido()
                        { IdPedido = ped.Value});
                    }
                }
                TempData["mensagem"] = MensagemModel.Serializar("Pedido não encontrado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }
            TempData["mensagem"] = MensagemModel.Serializar("Pedido não informado.", TipoMensagem.Erro);
            return RedirectToAction("Index", "Cliente");
        }

        private bool MotoristaExiste(int ped, int med)
        {
            return _context.MotoristasPedidos.Any(x => x.IdPedido == ped && x.IdMotorista == med);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] MotoristaPedido motoristaPedido)
        {
            if (ModelState.IsValid)
            {
                if (motoristaPedido.IdPedido > 0)
                {
                    var motorista = await _context.Motoristas.FindAsync(motoristaPedido.IdMotorista);
                    if (MotoristaExiste(motoristaPedido.IdPedido, motoristaPedido.IdMotorista))
                    {
                        _context.MotoristasPedidos.Update(motoristaPedido);
                        if (await _context.SaveChangesAsync() > 0)
                            TempData["mensagem"] = MensagemModel.Serializar("Motorista alterado com sucesso.");
                        else
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar motorista.", TipoMensagem.Erro);
                    }
                    else
                    {
                        _context.MotoristasPedidos.Add(motoristaPedido);
                        if (await _context.SaveChangesAsync() > 0)
                            TempData["mensagem"] = MensagemModel.Serializar("Motorista cadastrado com sucesso.");
                        else
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar motorista.", TipoMensagem.Erro);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { ped = motoristaPedido.IdPedido });
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Pedido não informado.", TipoMensagem.Erro);
                    return RedirectToAction("Index", "Cliente");
                }
            }
            else
            {
                var motoristas = _context.Motoristas
                        .OrderBy(x => x.NomeMotorista)
                        .Select(p => new { p.NomeMotorista })
                        .AsNoTracking().ToList();
                var motoristasSelectList = new SelectList(motoristas, "NomeMotorista");
                ViewBag.Motoristas = motoristasSelectList;

                return View(motoristaPedido);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? ped, int? med)
        {
            if (!ped.HasValue || !med.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Motorista do pedido não informado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }

            if (!MotoristaExiste(ped.Value, med.Value))
            {
                TempData["mensagem"] = MensagemModel.Serializar("Motorista do pedido não encontrado.", TipoMensagem.Erro);
                return RedirectToAction("Index", "Cliente");
            }

            var motoristaPedido = await _context.MotoristasPedidos.FindAsync(ped, med);
            _context.Entry(motoristaPedido).Reference(i => i.Motoristas).Load();
            return View(motoristaPedido);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int idPedido, int idMotorista)
        {
            var motoristaPedido = await _context.MotoristasPedidos.FindAsync(idPedido, idMotorista);
            if (motoristaPedido != null)
            {
                _context.MotoristasPedidos.Remove(motoristaPedido);
                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Motorista do pedido excluído com sucesso.");
                    var pedido = await _context.Pedidos.FindAsync(motoristaPedido.IdPedido);
                    await _context.SaveChangesAsync();
                }
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o motorista do pedido.", TipoMensagem.Erro);
                return RedirectToAction("Index", new { ped = idPedido });
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Motorista do pedido não encontrado.", TipoMensagem.Erro);
                return RedirectToAction("Index", new { ped = idPedido });
            }
        }
    }
}
