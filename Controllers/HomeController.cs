using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPaniMVCv2.Models;
using System.Diagnostics;

namespace PrjPaniMVCv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly PaniContext _context;

        public HomeController(PaniContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _context.Pedidos
                .Where(p => !p.DataPedido.HasValue)
                .Include(p => p.Cliente)
                .OrderByDescending(p => p.IdPedido)
                .AsNoTracking().ToListAsync();

            return View(pedidos);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}