using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroEventoAssociadov4.Data;
using RegistroEventoAssociadov4.Models;

namespace RegistroEventoAssociadov4.Controllers
{
    public class ConvidadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConvidadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Convidadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Convidados.ToListAsync());
        }

        // GET: Convidadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // GET: Convidadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Convidadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,RegistroGeral,Celular,Telefone,Email,Evento")] Convidado convidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convidado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convidado);
        }

        // GET: Convidadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidados.FindAsync(id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }

        // POST: Convidadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,RegistroGeral,Celular,Telefone,Email,Evento")] Convidado convidado)
        {
            if (id != convidado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convidado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvidadoExists(convidado.Id))
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
            return View(convidado);
        }

        // GET: Convidadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // POST: Convidadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convidado = await _context.Convidados.FindAsync(id);
            if (convidado != null)
            {
                _context.Convidados.Remove(convidado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvidadoExists(int id)
        {
            return _context.Convidados.Any(e => e.Id == id);
        }
    }
}
