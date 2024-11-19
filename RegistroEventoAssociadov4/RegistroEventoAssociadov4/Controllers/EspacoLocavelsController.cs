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
    public class EspacoLocavelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspacoLocavelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EspacoLocavels
        public async Task<IActionResult> Index()
        {
            return View(await _context.EspacosLocaveis.ToListAsync());
        }

        // GET: EspacoLocavels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacoLocavel = await _context.EspacosLocaveis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (espacoLocavel == null)
            {
                return NotFound();
            }

            return View(espacoLocavel);
        }

        // GET: EspacoLocavels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspacoLocavels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEspaco,Tamanho,CapacidadePessoas,DataConstrucao,Localvel")] EspacoLocavel espacoLocavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espacoLocavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(espacoLocavel);
        }

        // GET: EspacoLocavels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacoLocavel = await _context.EspacosLocaveis.FindAsync(id);
            if (espacoLocavel == null)
            {
                return NotFound();
            }
            return View(espacoLocavel);
        }

        // POST: EspacoLocavels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEspaco,Tamanho,CapacidadePessoas,DataConstrucao,Localvel")] EspacoLocavel espacoLocavel)
        {
            if (id != espacoLocavel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espacoLocavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspacoLocavelExists(espacoLocavel.Id))
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
            return View(espacoLocavel);
        }

        // GET: EspacoLocavels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacoLocavel = await _context.EspacosLocaveis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (espacoLocavel == null)
            {
                return NotFound();
            }

            return View(espacoLocavel);
        }

        // POST: EspacoLocavels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var espacoLocavel = await _context.EspacosLocaveis.FindAsync(id);
            if (espacoLocavel != null)
            {
                _context.EspacosLocaveis.Remove(espacoLocavel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspacoLocavelExists(int id)
        {
            return _context.EspacosLocaveis.Any(e => e.Id == id);
        }
    }
}
