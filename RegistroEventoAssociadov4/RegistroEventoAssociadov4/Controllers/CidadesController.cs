using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroEventoAssociadov4.Data;
using RegistroEventoAssociadov4.Models;

namespace RegistroEventoAssociadov4.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            var cidades = _context.Cidades.Include(c => c.Estado);
            return View(await cidades.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Nome");
            return View();
        }

        // POST: Cidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DDD,EstadoId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(cidade);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao salvar a cidade: " + ex.Message);
                }
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Nome", cidade.EstadoId);
            return View(cidade);
        }
    }
}
