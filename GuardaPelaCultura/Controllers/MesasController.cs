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
    public class MesasController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;

        public MesasController(GuardaPelaCulturaContext context)
        {
            _context = context;
        }

        // GET: Mesas
        /*public async Task<IActionResult> Index()
        {
            var guardaPelaCulturaContext = _context.Mesa.Include(m => m.Restaurantes);
            return View(await guardaPelaCulturaContext.ToListAsync());
        }*/

        // GET: Mesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesa
                .Include(m => m.Restaurantes)
                .FirstOrDefaultAsync(m => m.MesaId == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // GET: Mesas/Create
        public IActionResult Create()
        {
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante");
            return View();
        }

        // POST: Mesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MesaId,RestaurantesId,LugaresRestaurante,MesasRestaurante")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", mesa.RestaurantesId);
            return View(mesa);
        }

        // GET: Mesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", mesa.RestaurantesId);
            return View(mesa);
        }

        // POST: Mesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MesaId,RestaurantesId,LugaresRestaurante,MesasRestaurante")] Mesa mesa)
        {
            if (id != mesa.MesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesaExists(mesa.MesaId))
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
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", mesa.RestaurantesId);
            return View(mesa);
        }

        // GET: Mesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesa
                .Include(m => m.Restaurantes)
                .FirstOrDefaultAsync(m => m.MesaId == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesa = await _context.Mesa.FindAsync(id);
            _context.Mesa.Remove(mesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesaExists(int id)
        {
            return _context.Mesa.Any(e => e.MesaId == id);
        }

        public IActionResult Index(int page = 1, string name = null)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItem = _context.Mesa.Where(p => name == null || p.Restaurantes.NomeRestaurante.Contains(name)).Count()
            };
            var guardaPelaCulturaContext = _context.Mesa.Include(m => m.Restaurantes);
            return View(
            new ListaMesas
            {
                Mesa = _context.Mesa.Where(p => name == null || p.Restaurantes.NomeRestaurante.Contains(name))
                .OrderBy(page => page.Restaurantes).Skip((page -1)* pagination.PageSize).Take(pagination.PageSize).Include(m => m.Restaurantes),
                Paginacao = pagination
            }
            );
        }
    }
}
