using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroEventoAssociadov4.Data;
using RegistroEventoAssociadov4.Models;

namespace RegistroEventoAssociadov4.Controllers
{
    public class DependentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DependentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dependentes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dependentes.Include(d => d.SocioTitular);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dependentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependentes
                .Include(d => d.SocioTitular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // GET: Dependentes/Create
        public IActionResult Create()
        {
            ViewData["SocioTitularId"] = new SelectList(_context.Associados, "Id", "NomeTitular");
            return View();
        }

        // POST: Dependentes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,RG,DataNascimento,TipoVinculo,SocioTitularId")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(dependente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao salvar o dependente: " + ex.Message);
                }
            }
            ViewData["SocioTitularId"] = new SelectList(_context.Associados, "Id", "NomeTitular", dependente.SocioTitularId);
            return View(dependente);
        }

        // GET: Dependentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependentes.FindAsync(id);
            if (dependente == null)
            {
                return NotFound();
            }
            ViewData["SocioTitularId"] = new SelectList(_context.Associados, "Id", "NomeTitular", dependente.SocioTitularId);
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,RG,DataNascimento,TipoVinculo,SocioTitularId")] Dependente dependente)
        {
            if (id != dependente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenteExists(dependente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao atualizar o dependente: " + ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SocioTitularId"] = new SelectList(_context.Associados, "Id", "NomeTitular", dependente.SocioTitularId);
            return View(dependente);
        }

        // GET: Dependentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependentes
                .Include(d => d.SocioTitular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var dependente = await _context.Dependentes.FindAsync(id);
                if (dependente != null)
                {
                    _context.Dependentes.Remove(dependente);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao excluir o dependente: " + ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DependenteExists(int id)
        {
            return _context.Dependentes.Any(e => e.Id == id);
        }
    }
}
