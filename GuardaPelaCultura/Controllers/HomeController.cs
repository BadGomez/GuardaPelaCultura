using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuardaPelaCultura.Models;
using GuardaPelaCultura.Data;

namespace GuardaPelaCultura.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GuardaPelaCulturaContext _context;

        public HomeController(ILogger<HomeController> logger, GuardaPelaCulturaContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index(int page = 1)
        {
            var paginacao = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItem = _context.Restaurantes.Count()
            };
            return View(new ListaPaginaRestaurantes {
                Paginacao = paginacao,
                ListaRestaurantes = _context.Restaurantes.Skip((page - 1)*paginacao.PageSize).Take(paginacao.PageSize)
            });
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contacts()
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

