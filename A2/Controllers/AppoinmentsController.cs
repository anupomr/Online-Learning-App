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
    public class AppoinmentsController : Controller
    {
        private readonly AWSDSContext _context;

        public AppoinmentsController(AWSDSContext context)
        {
            _context = context;
        }

        // GET: Appoinments
        public async Task<IActionResult> Index()
        {
            var aWSDSContext = _context.Appoinment.Include(a => a.Student).Include(a => a.Teacher);
            return View(await aWSDSContext.ToListAsync());
        }

        // GET: Appoinments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.Appoinment
                .Include(a => a.Student)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AppoinmentId == id);
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        // GET: Appoinments/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId");
            return View();
        }

        // POST: Appoinments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppoinmentId,StudentId,TeacherId,AppoinmentDate,AppoinmentTime,AppoinmentCoz")] Appoinment appoinment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appoinment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", appoinment.StudentId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", appoinment.TeacherId);
            return View(appoinment);
        }

        // GET: Appoinments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.Appoinment.FindAsync(id);
            if (appoinment == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", appoinment.StudentId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", appoinment.TeacherId);
            return View(appoinment);
        }

        // POST: Appoinments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AppoinmentId,StudentId,TeacherId,AppoinmentDate,AppoinmentTime,AppoinmentCoz")] Appoinment appoinment)
        {
            if (id != appoinment.AppoinmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appoinment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppoinmentExists(appoinment.AppoinmentId))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", appoinment.StudentId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", appoinment.TeacherId);
            return View(appoinment);
        }

        // GET: Appoinments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appoinment = await _context.Appoinment
                .Include(a => a.Student)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AppoinmentId == id);
            if (appoinment == null)
            {
                return NotFound();
            }

            return View(appoinment);
        }

        // POST: Appoinments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appoinment = await _context.Appoinment.FindAsync(id);
            _context.Appoinment.Remove(appoinment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppoinmentExists(string id)
        {
            return _context.Appoinment.Any(e => e.AppoinmentId == id);
        }
    }
}
