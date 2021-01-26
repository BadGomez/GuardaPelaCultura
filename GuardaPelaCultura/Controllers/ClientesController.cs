using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuardaPelaCultura.Data;
using GuardaPelaCultura.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GuardaPelaCultura.Controllers
{
    public class ClientesController : Controller
    {
        private readonly GuardaPelaCulturaContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ClientesController(GuardaPelaCulturaContext context, UserManager<IdentityUser> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Clientes
        [Authorize(Roles = "GestorGPC")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        [Authorize(Roles = "GestorGPC")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Clientes/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterClienteViewModel clienteInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteInfo);
            }

            string username = clienteInfo.EmailCliente;

            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                ModelState.AddModelError("Email", "Já foi criada uma conta com este email.");
                return View(clienteInfo);
            }

            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, clienteInfo.Password);
            await _userManager.AddToRoleAsync(user, "Cliente");

            Cliente cliente = new Cliente
            {
                NomeCliente = clienteInfo.NomeCliente,
                NumeroTelefoneCliente = clienteInfo.NumeroTelefoneCliente,
                NifCliente = clienteInfo.NifCliente,
                EmailCliente = clienteInfo.EmailCliente
            };
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> EditPersonalData()
        {
            string email = User.Identity.Name;

            var cliente = await _context.Cliente.SingleOrDefaultAsync(c => c.EmailCliente == email);
            if (cliente == null)
            {
                return NotFound();
            }

            EditLoggedInClienteViewModel clienteInfo = new EditLoggedInClienteViewModel
            {
                NomeCliente = cliente.NomeCliente,
                NumeroTelefoneCliente = cliente.NumeroTelefoneCliente,
                NifCliente = cliente.NifCliente,
                EmailCliente = cliente.EmailCliente
            };

            return View(clienteInfo);
        }

        //POST: Cliente/EditLoggedInClienteViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = "Cliente")]
        public async Task<IActionResult> EditPersonalData(EditLoggedInClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            string email = User.Identity.Name;

            var clienteLoggedIn = await _context.Cliente.SingleOrDefaultAsync(c => c.EmailCliente == email);
            if(clienteLoggedIn == null)
            {
                return NotFound();
            }

            clienteLoggedIn.NomeCliente = cliente.NomeCliente;

            try
            {
                _context.Update(clienteLoggedIn);
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {

                ModelState.AddModelError("Email", "Falha ao atualizar dados");
                throw;
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        // GET: Clientes/Edit/5
        [Authorize(Roles = "GestorGPC")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "GestorGPC")]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,NomeCliente,NumeroTelefoneCliente,NifCliente,EmailCliente")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            return View(cliente);
        }

     /*   // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }
    }
}
