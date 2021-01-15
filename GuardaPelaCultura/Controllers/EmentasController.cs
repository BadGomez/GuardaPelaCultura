using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaPelaCultura.Data;
using GuardaPelaCultura.Models;

namespace GuardaPelaCultura.Controllers
{
    public class EmentasController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;

        public EmentasController(GuardaPelaCulturaContext context)
        {
            _context = context;
        }

        // GET: Ementas
        /*public async Task<IActionResult> Index()
        {
            var guardaPelaCulturaContext = _context.Produtos.Include(e => e.Restaurantes);
            return View(await guardaPelaCulturaContext.ToListAsync());
        }*/

        // GET: Ementas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ementa = await _context.Produtos
                .Include(e => e.Restaurantes)
                .FirstOrDefaultAsync(m => m.EmentaId == id);
            if (ementa == null)
            {
                return NotFound();
            }

            return View(ementa);
        }

        // GET: Ementas/Create
        public IActionResult Create()
        {
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante");
            return View();
        }

        // POST: Ementas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmentaId,NomeEmenta,DescricaoEmenta,PrecoEmenta,QuantidadeEmenta,RestaurantesId")] Ementa ementa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ementa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", ementa.RestaurantesId);
            return View(ementa);
        }

        // GET: Ementas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ementa = await _context.Produtos.FindAsync(id);
            if (ementa == null)
            {
                return NotFound();
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", ementa.RestaurantesId);
            return View(ementa);
        }

        // POST: Ementas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmentaId,NomeEmenta,DescricaoEmenta,PrecoEmenta,QuantidadeEmenta,RestaurantesId")] Ementa ementa)
        {
            if (id != ementa.EmentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ementa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmentaExists(ementa.EmentaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", ementa.RestaurantesId);
            return View(ementa);
        }

        // GET: Ementas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ementa = await _context.Produtos
                .Include(e => e.Restaurantes)
                .FirstOrDefaultAsync(m => m.EmentaId == id);
            if (ementa == null)
            {
                return NotFound();
            }

            return View(ementa);
        }

        // POST: Ementas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ementa = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(ementa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmentaExists(int id)
        {
            return _context.Produtos.Any(e => e.EmentaId == id);
        }

        public IActionResult Index(int page = 1) 
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItem = _context.Produtos.Count()
            };
            return View(
            new EmentaListViewModel
            {
                Ementas = _context.Produtos.OrderBy(page => page.NomeEmenta)
            .Skip((page - 1) * pagination.PageSize).Take(pagination.PageSize),
                Pagination = pagination
            }
            );
        }
    }
}
