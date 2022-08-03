using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GeosMacros.Controllers
{
    public class NutritionController : Controller
    {
        private readonly Context _context;

        public NutritionController(Context context)
        {
            _context = context;
        }

        // GET: Nutrition
        public async Task<IActionResult> Index()
        {
              return _context.Nutrition != null ? 
                          View(await _context.Nutrition.ToListAsync()) :
                          Problem("Entity set 'Context.Nutrition'  is null.");
        }

        // GET: Nutrition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nutrition == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutrition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        // GET: Nutrition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nutrition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Item,Serving,Calories,Proteins,Carbohydrates,Fats,Quantity,Today")] Nutrition nutrition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nutrition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nutrition);
        }

        // GET: Nutrition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nutrition == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutrition.FindAsync(id);
            if (nutrition == null)
            {
                return NotFound();
            }
            return View(nutrition);
        }

        // POST: Nutrition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Item,Serving,Calories,Proteins,Carbohydrates,Fats,Quantity,Today")] Nutrition nutrition)
        {
            if (id != nutrition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nutrition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NutritionExists(nutrition.ID))
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
            return View(nutrition);
        }

        // GET: Nutrition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nutrition == null)
            {
                return NotFound();
            }

            var nutrition = await _context.Nutrition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        // POST: Nutrition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nutrition == null)
            {
                return Problem("Entity set 'Context.Nutrition'  is null.");
            }
            var nutrition = await _context.Nutrition.FindAsync(id);
            if (nutrition != null)
            {
                _context.Nutrition.Remove(nutrition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NutritionExists(int id)
        {
          return (_context.Nutrition?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
