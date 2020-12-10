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
    public class RestaurantesController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;

        public RestaurantesController(GuardaPelaCulturaContext context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurantes.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantes = await _context.Restaurantes
                .FirstOrDefaultAsync(m => m.RestaurantesId == id);
            if (restaurantes == null)
            {
                return NotFound();
            }

            return View(restaurantes);
        }

        // GET: Restaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestaurantesId,NomeRestaurante,NumeroTelefone,LugaresRestaurante,MesasRestaurante,EmailRestaurante,LocalizacaoRestaurante,TextoDescritivoRestaurante,HorarioRestaurante")] Restaurantes restaurantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantes);
        }

        // GET: Restaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantes = await _context.Restaurantes.FindAsync(id);
            if (restaurantes == null)
            {
                return NotFound();
            }
            return View(restaurantes);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestaurantesId,NomeRestaurante,NumeroTelefone,LugaresRestaurante,MesasRestaurante,EmailRestaurante,LocalizacaoRestaurante,TextoDescritivoRestaurante,HorarioRestaurante")] Restaurantes restaurantes)
        {
            if (id != restaurantes.RestaurantesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantesExists(restaurantes.RestaurantesId))
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
            return View(restaurantes);
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantes = await _context.Restaurantes
                .FirstOrDefaultAsync(m => m.RestaurantesId == id);
            if (restaurantes == null)
            {
                return NotFound();
            }

            return View(restaurantes);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantes = await _context.Restaurantes.FindAsync(id);
            _context.Restaurantes.Remove(restaurantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantesExists(int id)
        {
            return _context.Restaurantes.Any(e => e.RestaurantesId == id);
        }
    }
}
