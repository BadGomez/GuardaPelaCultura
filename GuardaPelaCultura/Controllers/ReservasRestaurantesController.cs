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
    public class ReservasRestaurantesController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;

        public ReservasRestaurantesController(GuardaPelaCulturaContext context)
        {
            _context = context;
        }

        // GET: ReservasRestaurantes
        public async Task<IActionResult> Index()
        {
            var guardaPelaCulturaContext = _context.ReservasRestaurante.Include(r => r.Restaurantes);
            return View(await guardaPelaCulturaContext.ToListAsync());
        }

        // GET: ReservasRestaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasRestaurante = await _context.ReservasRestaurante
                .Include(r => r.Restaurantes)
                .FirstOrDefaultAsync(m => m.ReservasRestauranteId == id);
            if (reservasRestaurante == null)
            {
                return NotFound();
            }

            return View(reservasRestaurante);
        }

        // GET: ReservasRestaurantes/Create
        public IActionResult Create()
        {
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante");
            return View();
        }

        // POST: ReservasRestaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservasRestauranteId,RestaurantesId,NomeReserva,NumeroPessoas,NumeroTelefoneReserva,Descricao")] ReservasRestaurante reservasRestaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservasRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "EmailRestaurante", reservasRestaurante.RestaurantesId);
            return View(reservasRestaurante);
        }

        // GET: ReservasRestaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasRestaurante = await _context.ReservasRestaurante.FindAsync(id);
            if (reservasRestaurante == null)
            {
                return NotFound();
            }
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "EmailRestaurante", reservasRestaurante.RestaurantesId);
            return View(reservasRestaurante);
        }

        // POST: ReservasRestaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservasRestauranteId,RestaurantesId,NomeReserva,NumeroPessoas,NumeroTelefoneReserva,Descricao")] ReservasRestaurante reservasRestaurante)
        {
            if (id != reservasRestaurante.ReservasRestauranteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservasRestaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservasRestauranteExists(reservasRestaurante.ReservasRestauranteId))
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
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "EmailRestaurante", reservasRestaurante.RestaurantesId);
            return View(reservasRestaurante);
        }

        // GET: ReservasRestaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasRestaurante = await _context.ReservasRestaurante
                .Include(r => r.Restaurantes)
                .FirstOrDefaultAsync(m => m.ReservasRestauranteId == id);
            if (reservasRestaurante == null)
            {
                return NotFound();
            }

            return View(reservasRestaurante);
        }

        // POST: ReservasRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservasRestaurante = await _context.ReservasRestaurante.FindAsync(id);
            _context.ReservasRestaurante.Remove(reservasRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservasRestauranteExists(int id)
        {
            return _context.ReservasRestaurante.Any(e => e.ReservasRestauranteId == id);
        }
    }
}
