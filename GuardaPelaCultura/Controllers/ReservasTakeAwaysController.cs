﻿using System;
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
    public class ReservasTakeAwaysController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;

        public ReservasTakeAwaysController(GuardaPelaCulturaContext context)
        {
            _context = context;
        }

        // GET: ReservasTakeAways
        [Authorize(Roles = "GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservasTakeAway.ToListAsync());
        }

        // GET: ReservasTakeAways/Details/5

        [Authorize(Roles = "GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasTakeAway = await _context.ReservasTakeAway
                .FirstOrDefaultAsync(m => m.ReservasTakeAwayId == id);
            if (reservasTakeAway == null)
            {
                return NotFound();
            }

            return View(reservasTakeAway);
        }


        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        // GET: ReservasTakeAways/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservasTakeAways/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Cliente, GestorGPC, GestorRestaurante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservasTakeAwayId,NomeRestaurante,Nome,NumeroTelefone,ObservacaoTakeAway")] ReservasTakeAway reservasTakeAway)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservasTakeAway);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"Home");
            }
            return View(reservasTakeAway);
        }

        // GET: ReservasTakeAways/Edit/5
        [Authorize(Roles = "GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasTakeAway = await _context.ReservasTakeAway.FindAsync(id);
            if (reservasTakeAway == null)
            {
                return NotFound();
            }
            return View(reservasTakeAway);
        }

        // POST: ReservasTakeAways/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "GestorGPC, GestorRestaurante")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservasTakeAwayId,NomeRestaurante,Nome,NumeroTelefone,ObservacaoTakeAway")] ReservasTakeAway reservasTakeAway)
        {
            if (id != reservasTakeAway.ReservasTakeAwayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservasTakeAway);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservasTakeAwayExists(reservasTakeAway.ReservasTakeAwayId))
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
            return View(reservasTakeAway);
        }

        // GET: ReservasTakeAways/Delete/5
        [Authorize(Roles = "GestorGPC, GestorRestaurante")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasTakeAway = await _context.ReservasTakeAway
                .FirstOrDefaultAsync(m => m.ReservasTakeAwayId == id);
            if (reservasTakeAway == null)
            {
                return NotFound();
            }

            return View(reservasTakeAway);
        }

        // POST: ReservasTakeAways/Delete/5
        [Authorize(Roles = "GestorGPC, GestorRestaurante")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservasTakeAway = await _context.ReservasTakeAway.FindAsync(id);
            _context.ReservasTakeAway.Remove(reservasTakeAway);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservasTakeAwayExists(int id)
        {
            return _context.ReservasTakeAway.Any(e => e.ReservasTakeAwayId == id);
        }
    }
}
