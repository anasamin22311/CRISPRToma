using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRISPR.Data;
using CRISPR.Models;

namespace CRISPR.Controllers
{
    public class GeneCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeneCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GeneCodes
        public async Task<IActionResult> Index()
        {
              return View(await _context.GeneCode.ToListAsync());
        }

        // GET: GeneCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneCode == null)
            {
                return NotFound();
            }

            var geneCode = await _context.GeneCode
                .FirstOrDefaultAsync(m => m.id == id);
            if (geneCode == null)
            {
                return NotFound();
            }

            return View(geneCode);
        }

        // GET: GeneCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tilte,SubTilte,Description,RepositoryURL,Licenses,Accuracy")] GeneCode geneCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geneCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geneCode);
        }

        // GET: GeneCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneCode == null)
            {
                return NotFound();
            }

            var geneCode = await _context.GeneCode.FindAsync(id);
            if (geneCode == null)
            {
                return NotFound();
            }
            return View(geneCode);
        }

        // POST: GeneCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Tilte,SubTilte,Description,RepositoryURL,Licenses,Accuracy")] GeneCode geneCode)
        {
            if (id != geneCode.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geneCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneCodeExists(geneCode.id))
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
            return View(geneCode);
        }

        // GET: GeneCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneCode == null)
            {
                return NotFound();
            }

            var geneCode = await _context.GeneCode
                .FirstOrDefaultAsync(m => m.id == id);
            if (geneCode == null)
            {
                return NotFound();
            }

            return View(geneCode);
        }

        // POST: GeneCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneCode == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GeneCode'  is null.");
            }
            var geneCode = await _context.GeneCode.FindAsync(id);
            if (geneCode != null)
            {
                _context.GeneCode.Remove(geneCode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneCodeExists(int id)
        {
          return _context.GeneCode.Any(e => e.id == id);
        }
    }
}
