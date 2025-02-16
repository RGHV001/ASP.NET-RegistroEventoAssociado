using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroEventoAssociadov4.Data;
using RegistroEventoAssociadov4.Models;
using System.Threading.Tasks;

namespace RegistroEventoAssociadov4.Controllers
{
    public class EventoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            var eventos = _context.Eventos
                .Include(e => e.EspacoLocavel)
                .Include(e => e.Responsavel);

            return View(await eventos.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.EspacoLocavel)
                .Include(e => e.Responsavel)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            ViewData["EspacoLocavelId"] = new SelectList(_context.EspacosLocaveis, "Id", "NomeEspaco");
            ViewData["ResponsavelId"] = new SelectList(_context.Associados, "Id", "NomeTitular");
            return View();
        }

        // POST: Eventoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,EspacoLocavelId,DataInicio,HoraInicio,DataFim,HoraFim,ResponsavelId,ValorLocacao")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(evento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao salvar o evento: {ex.Message}");
                }
            }

            ViewData["EspacoLocavelId"] = new SelectList(_context.EspacosLocaveis, "Id", "NomeEspaco", evento.EspacoLocavelId);
            ViewData["ResponsavelId"] = new SelectList(_context.Associados, "Id", "NomeTitular", evento.ResponsavelId);
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            ViewData["EspacoLocavelId"] = new SelectList(_context.EspacosLocaveis, "Id", "NomeEspaco", evento.EspacoLocavelId);
            ViewData["ResponsavelId"] = new SelectList(_context.Associados, "Id", "NomeTitular", evento.ResponsavelId);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,EspacoLocavelId,DataInicio,HoraInicio,DataFim,HoraFim,ResponsavelId,ValorLocacao")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
                    ModelState.AddModelError("", $"Erro ao atualizar o evento: {ex.Message}");
                }
            }

            ViewData["EspacoLocavelId"] = new SelectList(_context.EspacosLocaveis, "Id", "NomeEspaco", evento.EspacoLocavelId);
            ViewData["ResponsavelId"] = new SelectList(_context.Associados, "Id", "NomeTitular", evento.ResponsavelId);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.EspacoLocavel)
                .Include(e => e.Responsavel)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);

            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
