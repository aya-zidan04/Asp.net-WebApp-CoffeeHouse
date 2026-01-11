using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coffee_House_Aya.Models;

namespace Coffee_House_Aya.Controllers
{
    public class SweetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SweetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sweets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sweets.ToListAsync());
        }

        // GET: Sweets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweet = await _context.Sweets
                .FirstOrDefaultAsync(m => m.SweetId == id);
            if (sweet == null)
            {
                return NotFound();
            }

            return View(sweet);
        }

        // GET: Sweets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sweets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SweetId,SweetName,Description,Type,Price,SImage")] Sweet sweet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweet);
        }

        // GET: Sweets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweet = await _context.Sweets.FindAsync(id);
            if (sweet == null)
            {
                return NotFound();
            }
            return View(sweet);
        }

        // POST: Sweets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SweetId,SweetName,Description,Type,Price,SImage")] Sweet sweet)
        {
            if (id != sweet.SweetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetExists(sweet.SweetId))
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
            return View(sweet);
        }

        // GET: Sweets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweet = await _context.Sweets
                .FirstOrDefaultAsync(m => m.SweetId == id);
            if (sweet == null)
            {
                return NotFound();
            }

            return View(sweet);
        }

        // POST: Sweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sweet = await _context.Sweets.FindAsync(id);
            if (sweet != null)
            {
                _context.Sweets.Remove(sweet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetExists(int id)
        {
            return _context.Sweets.Any(e => e.SweetId == id);
        }
    }
}
