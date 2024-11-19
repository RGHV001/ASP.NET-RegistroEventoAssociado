using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroEventoAssociadov4.Data;
using RegistroEventoAssociadov4.Models;

namespace RegistroEventoAssociadov4.Controllers
{
    public class AssociadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Associadoes
        public async Task<IActionResult> Index()
        {
            // Carrega apenas os campos cruciais para exibição na lista
            var associados = await _context.Associados
                .Select(a => new Associado
                {
                    Id = a.Id,
                    NomeTitular = a.NomeTitular,
                    Celular = a.Celular,
                    CPF = a.CPF,
                    TipoDeAssociacao = a.TipoDeAssociacao
                })
                .ToListAsync();

            return View(associados);
        }

        // GET: Associadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Carrega todos os campos do associado para exibição nos detalhes
            var associado = await _context.Associados
                .FirstOrDefaultAsync(m => m.Id == id);

            if (associado == null)
            {
                return NotFound();
            }

            return View(associado);
        }

        // GET: Associadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associadoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTitular,Endereco,Bairro,Cep,Complemento,Cidade,UF,Telefone,Celular,Email,Facebook,Instagram,CPF,RegistroGeral,DataNascimento,TipoDeAssociacao")] Associado associado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(associado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associado);
        }

        // GET: Associadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados.FindAsync(id);
            if (associado == null)
            {
                return NotFound();
            }
            return View(associado);
        }

        // POST: Associadoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTitular,Endereco,Bairro,Cep,Complemento,Cidade,UF,Telefone,Celular,Email,Facebook,Instagram,CPF,RegistroGeral,DataNascimento,TipoDeAssociacao")] Associado associado)
        {
            if (id != associado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociadoExists(associado.Id))
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
            return View(associado);
        }

        // GET: Associadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados
                .FirstOrDefaultAsync(m => m.Id == id);

            if (associado == null)
            {
                return NotFound();
            }

            return View(associado);
        }

        // POST: Associadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var associado = await _context.Associados.FindAsync(id);
            if (associado != null)
            {
                _context.Associados.Remove(associado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociadoExists(int id)
        {
            return _context.Associados.Any(e => e.Id == id);
        }
    }
}
