using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A2.Models;

namespace A2.Controllers
{
    public class RatingsController : Controller
    {
        private readonly AWSDSContext _context;

        public RatingsController(AWSDSContext context)
        {
            _context = context;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            var aWSDSContext = _context.Rating.Include(r => r.Student);
            return View(await aWSDSContext.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RatingId == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RatingId,StudentId,Comment")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", rating.StudentId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", rating.StudentId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RatingId,StudentId,Comment")] Rating rating)
        {
            if (id != rating.RatingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.RatingId))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", rating.StudentId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RatingId == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rating = await _context.Rating.FindAsync(id);
            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(string id)
        {
            return _context.Rating.Any(e => e.RatingId == id);
        }
    }
}
