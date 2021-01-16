using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaPelaCultura.Data;
using GuardaPelaCultura.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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
        public async Task<IActionResult> Create([Bind("RestaurantesId,NomeRestaurante,NumeroTelefone,EmailRestaurante,LocalizacaoRestaurante,TextoDescritivoRestaurante,HoraAbertura," +
            "HoraFecho")] Restaurantes restaurantes, List<IFormFile> Imagem, List<IFormFile> Imagem1, List<IFormFile> Imagem2, List<IFormFile> Imagem3)
        {
            foreach (var item in Imagem)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        restaurantes.Imagem = stream.ToArray();
                    }
                }
            }
            foreach (var item in Imagem1)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        restaurantes.Imagem1 = stream.ToArray();
                    }
                }
            }
            foreach (var item in Imagem2)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        restaurantes.Imagem2 = stream.ToArray();
                    }
                }
            }
            foreach (var item in Imagem3)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        restaurantes.Imagem3 = stream.ToArray();
                    }
                }
            }

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
        public async Task<IActionResult> Edit(int id, [Bind("RestaurantesId,NomeRestaurante,NumeroTelefone,EmailRestaurante,LocalizacaoRestaurante,TextoDescritivoRestaurante," +
            "HoraAbertura,HoraFecho")] Restaurantes restaurantes, List<IFormFile> Imagem, List<IFormFile> Imagem1, List<IFormFile> Imagem2, List<IFormFile> Imagem3)
        {
            if (id != restaurantes.RestaurantesId)
            {
                return NotFound();
            }
            
            Restaurantes TodosDadosRestaurante = await _context.Restaurantes.FindAsync(id);

            if (Imagem.Count() != 0)
            {
                foreach (var item in Imagem)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            TodosDadosRestaurante.Imagem = stream.ToArray();
                        }
                    }
                }
            }

            if (Imagem1.Count() != 0)
            {
                foreach (var item in Imagem1)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            TodosDadosRestaurante.Imagem1 = stream.ToArray();
                        }
                    }
                }
            }

            if (Imagem2.Count() != 0)
            {
                foreach (var item in Imagem2)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            TodosDadosRestaurante.Imagem2 = stream.ToArray();
                        }

                    }
                }
            }
            if (Imagem3.Count() != 0)
            {
                foreach (var item in Imagem3)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            TodosDadosRestaurante.Imagem3 = stream.ToArray();
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TodosDadosRestaurante.EmailRestaurante = restaurantes.EmailRestaurante;
                    TodosDadosRestaurante.NomeRestaurante = restaurantes.NomeRestaurante;
                    TodosDadosRestaurante.NumeroTelefone = restaurantes.NumeroTelefone;
                    TodosDadosRestaurante.LocalizacaoRestaurante = restaurantes.LocalizacaoRestaurante;
                    TodosDadosRestaurante.TextoDescritivoRestaurante = restaurantes.TextoDescritivoRestaurante;
                    TodosDadosRestaurante.HoraAbertura = restaurantes.HoraAbertura;
                    TodosDadosRestaurante.HoraFecho = restaurantes.HoraFecho;
                    restaurantes = TodosDadosRestaurante;

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
