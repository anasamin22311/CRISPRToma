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
    public class DataSetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataSetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataSets
        public async Task<IActionResult> Index()
        {
              return View(await _context.DataSet.ToListAsync());
        }

        // GET: DataSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataSet == null)
            {
                return NotFound();
            }

            var dataSet = await _context.DataSet
                .FirstOrDefaultAsync(m => m.id == id);
            if (dataSet == null)
            {
                return NotFound();
            }

            return View(dataSet);
        }

        // GET: DataSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tilte,SubTilte,Description,RepositoryURL,Licenses,FileType,FileSize,FileURL,Accuracy")] DataSet dataSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataSet);
        }

        // GET: DataSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataSet == null)
            {
                return NotFound();
            }

            var dataSet = await _context.DataSet.FindAsync(id);
            if (dataSet == null)
            {
                return NotFound();
            }
            return View(dataSet);
        }

        // POST: DataSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Tilte,SubTilte,Description,RepositoryURL,Licenses,FileType,FileSize,FileURL,Accuracy")] DataSet dataSet)
        {
            if (id != dataSet.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataSetExists(dataSet.id))
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
            return View(dataSet);
        }

        // GET: DataSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataSet == null)
            {
                return NotFound();
            }

            var dataSet = await _context.DataSet
                .FirstOrDefaultAsync(m => m.id == id);
            if (dataSet == null)
            {
                return NotFound();
            }

            return View(dataSet);
        }

        // POST: DataSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataSet == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataSet'  is null.");
            }
            var dataSet = await _context.DataSet.FindAsync(id);
            if (dataSet != null)
            {
                _context.DataSet.Remove(dataSet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataSetExists(int id)
        {
          return _context.DataSet.Any(e => e.id == id);
        }
    }
}
