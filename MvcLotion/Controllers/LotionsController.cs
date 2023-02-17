using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLotion.Data;
using MvcLotion.Models;

namespace MvcLotion.Controllers
{
    public class LotionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LotionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lotions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lotion.ToListAsync());
        }

        // GET: Lotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotion = await _context.Lotion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lotion == null)
            {
                return NotFound();
            }

            return View(lotion);
        }

        // GET: Lotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ingredients,SkinType,Texture,Purpose,Scent,Price")] Lotion lotion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lotion);
        }

        // GET: Lotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotion = await _context.Lotion.FindAsync(id);
            if (lotion == null)
            {
                return NotFound();
            }
            return View(lotion);
        }

        // POST: Lotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ingredients,SkinType,Texture,Purpose,Scent,Price")] Lotion lotion)
        {
            if (id != lotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotionExists(lotion.Id))
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
            return View(lotion);
        }

        // GET: Lotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotion = await _context.Lotion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lotion == null)
            {
                return NotFound();
            }

            return View(lotion);
        }

        // POST: Lotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lotion = await _context.Lotion.FindAsync(id);
            _context.Lotion.Remove(lotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotionExists(int id)
        {
            return _context.Lotion.Any(e => e.Id == id);
        }
    }
}
