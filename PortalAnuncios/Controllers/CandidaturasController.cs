using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelagemBd;
using PortalAnuncios.Data;

namespace PortalAnuncios.Controllers
{
    public class CandidaturasController : Controller
    {
        private readonly PortalAnunciosContext _context;

        public CandidaturasController(PortalAnunciosContext context)
        {
            _context = context;
        }

        // GET: Candidaturas
        public async Task<IActionResult> Index()
        {
            var portalAnunciosContext = _context.Candidatura.Include(c => c.Anuncio).Include(c => c.Candidato);
            return View(await portalAnunciosContext.ToListAsync());
        }

        // GET: Candidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidatura == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura
                .Include(c => c.Anuncio)
                .Include(c => c.Candidato)
                .Include(c => c.Historico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Create
        public IActionResult Create()
        {
            ViewData["AnuncioId"] = new SelectList(_context.Anuncio, "Id", "Titulo");
            ViewData["CandidatoId"] = new SelectList(_context.Cliente, "Id", "Nome");
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnuncioId,CandidatoId,Status")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                candidatura.Historico = new List<CandidaturaHistorico>();
                candidatura.Historico.Add(new CandidaturaHistorico()
                        { DataDoStatus = DateTime.Now, Status = candidatura.Status });
                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnuncioId"] = new SelectList(_context.Anuncio, "Id", "Descricao", candidatura.AnuncioId);
            ViewData["CandidatoId"] = new SelectList(_context.Cliente, "Id", "Nome", candidatura.CandidatoId);
            return View(candidatura);
        }

        // GET: Candidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidatura == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura.FindAsync(id);
            if (candidatura == null)
            {
                return NotFound();
            }
            ViewData["AnuncioId"] = new SelectList(_context.Anuncio, "Id", "Descricao", candidatura.AnuncioId);
            ViewData["CandidatoId"] = new SelectList(_context.Cliente, "Id", "Nome", candidatura.CandidatoId);
            return View(candidatura);
        }

        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnuncioId,CandidatoId,Status")] Candidatura candidatura)
        {
            if (id != candidatura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatura);
                    var historico = new CandidaturaHistorico()
                    {
                        CandidaturaId = candidatura.Id,
                        DataDoStatus = DateTime.Now,
                        Status = candidatura.Status
                    };
                    _context.Add(historico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaExists(candidatura.Id))
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
            ViewData["AnuncioId"] = new SelectList(_context.Anuncio, "Id", "Descricao", candidatura.AnuncioId);
            ViewData["CandidatoId"] = new SelectList(_context.Cliente, "Id", "Nome", candidatura.CandidatoId);
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidatura == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura
                .Include(c => c.Anuncio)
                .Include(c => c.Candidato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidatura == null)
            {
                return Problem("Entity set 'PortalAnunciosContext.Candidatura'  is null.");
            }
            var candidatura = await _context.Candidatura.FindAsync(id);
            if (candidatura != null)
            {
                _context.Candidatura.Remove(candidatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaExists(int id)
        {
          return (_context.Candidatura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
