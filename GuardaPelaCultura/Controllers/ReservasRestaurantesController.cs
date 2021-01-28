using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaPelaCultura.Data;
using GuardaPelaCultura.Models;
using Microsoft.AspNetCore.Authorization;

namespace GuardaPelaCultura.Controllers
{
    //[Authorize(Roles = "GestorGPC, GestorRestaurante")]
    public class ReservasRestaurantesController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;

        public ReservasRestaurantesController(GuardaPelaCulturaContext context)
        {
            _context = context;
        }

        // GET: ReservasRestaurantes
        /*public async Task<IActionResult> Index()
        {
            var guardaPelaCulturaContext = _context.ReservasRestaurante.Include(r => r.Cliente).Include(r => r.Mesa).Include(r => r.Restaurantes);
            return View(await guardaPelaCulturaContext.ToListAsync());
        }*/

        // GET: ReservasRestaurantes/Details/5
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasRestaurante = await _context.ReservasRestaurante
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .Include(r => r.Restaurantes)
                .FirstOrDefaultAsync(m => m.ReservasRestauranteId == id);
            if (reservasRestaurante == null)
            {
                return NotFound();
            }

            return View(reservasRestaurante);
        }

        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        // GET: ReservasRestaurantes/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["MesaId"] = new SelectList(_context.Mesa, "MesaId", "MesasRestaurante");
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante");
            return View();
        }

        // POST: ReservasRestaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservasRestauranteId,RestaurantesId,MesaId,NumeroPessoas,EstadoReserva,DataReserva,ObservacaoReserva")] ReservasRestaurante reservasRestaurante)
        {
            if (ModelState.IsValid)
            {
                string email = User.Identity.Name;

                var cliente = await _context.Cliente.SingleOrDefaultAsync(c => c.EmailCliente == email);
                if (cliente == null)
                {
                    return NotFound();
                }
                reservasRestaurante.Cliente = cliente;
                _context.Add(reservasRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = reservasRestaurante.ReservasRestauranteId.ToString()});
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", reservasRestaurante.ClienteId);
            ViewData["MesaId"] = new SelectList(_context.Mesa, "MesaId", "MesasRestaurante", reservasRestaurante.MesaId);
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", reservasRestaurante.RestaurantesId);
            return View(reservasRestaurante);
        }

        // GET: ReservasRestaurantes/Edit/5
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", reservasRestaurante.ClienteId);
            ViewData["MesaId"] = new SelectList(_context.Mesa, "MesaId", "MesasRestaurante", reservasRestaurante.MesaId);
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", reservasRestaurante.RestaurantesId);
            return View(reservasRestaurante);
        }

        // POST: ReservasRestaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservasRestauranteId,RestaurantesId,ClienteId,MesaId,NumeroPessoas,EstadoReserva,DataReserva,ObservacaoReserva")] ReservasRestaurante reservasRestaurante)
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
                return RedirectToAction(nameof(Details), new { id = reservasRestaurante.ReservasRestauranteId.ToString() });
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "NomeCliente", reservasRestaurante.ClienteId);
            ViewData["MesaId"] = new SelectList(_context.Mesa, "MesaId", "MesasRestaurante", reservasRestaurante.MesaId);
            ViewData["RestaurantesId"] = new SelectList(_context.Restaurantes, "RestaurantesId", "NomeRestaurante", reservasRestaurante.RestaurantesId);
            return View(reservasRestaurante);
        }

        // GET: ReservasRestaurantes/Delete/5
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasRestaurante = await _context.ReservasRestaurante
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .Include(r => r.Restaurantes)
                .FirstOrDefaultAsync(m => m.ReservasRestauranteId == id);
            if (reservasRestaurante == null)
            {
                return NotFound();
            }

            return View(reservasRestaurante);
        }

        // POST: ReservasRestaurantes/Delete/5
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservasRestaurante = await _context.ReservasRestaurante.FindAsync(id);
            _context.ReservasRestaurante.Remove(reservasRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Home");
        }

        private bool ReservasRestauranteExists(int id)
        {
            return _context.ReservasRestaurante.Any(e => e.ReservasRestauranteId == id);
        }

        [Authorize(Roles = "Cliente,GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> IndexAsync(string name = null, int page = 1)
        {
            string email = User.Identity.Name;
            var cliente = await _context.Cliente.SingleOrDefaultAsync(c => c.EmailCliente == email);
            if (cliente == null)
            {
                if (User.IsInRole("GestorGPC") || User.IsInRole("GestorRestaurante"))
                {
                    
                }
                else
                {
                    return NotFound();
                }
            }

            if (User.IsInRole("Cliente")) { 
            
                if(_context.ReservasRestaurante.Where(p => p.ClienteId == cliente.ClienteId).Count() == 0)
                {
                    return RedirectToAction("Index","Home");
                }
                var guardaPelaCulturaContext = _context.ReservasRestaurante.Include(r => r.Cliente).Include(r => r.Mesa).Include(r => r.Restaurantes);
                return View(
                new ReservaRestauranteListViewModel
                {
                    ReservaRestaurantes = _context.ReservasRestaurante.Where(p => p.ClienteId == cliente.ClienteId)
                    .OrderBy(page => page.DataReserva).Include(r => r.Cliente).Include(r => r.Mesa).Include(r => r.Restaurantes),
                }
                ) ;
            }
            else
            {
                var pagination = new PagingInfo
                {
                    CurrentPage = page,
                    PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                    TotalItem = _context.ReservasRestaurante.Where(p => name == null || p.Cliente.NomeCliente.Contains(name)).Count()
                };
                var guardaPelaCulturaContext = _context.ReservasRestaurante.Include(r => r.Cliente).Include(r => r.Mesa).Include(r => r.Restaurantes);
                return View(
                new ReservaRestauranteListViewModel
                {

                    ReservaRestaurantes = _context.ReservasRestaurante.Where(p => name == null || p.Cliente.NomeCliente.Contains(name)).OrderBy(page => page.DataReserva).Skip((page - 1) * pagination.PageSize).Take(pagination.PageSize).Include(r => r.Cliente).Include(r => r.Mesa).Include(r => r.Restaurantes),
                    Paginacao = pagination,
                    SearchName = name
                }
                );
            }
        }
    }
}
