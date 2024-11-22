using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonorManagementAPI.Data;
using DonorManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonorManagementAPI.Controllers
{
    [Route("[controller]")]
    public class DonorsController : Controller
    {
        private readonly DonorManagementContext _context;

        public DonorsController(DonorManagementContext context)
        {
            _context = context;
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var donors = await _context.Donors.ToListAsync();
            return View(donors); // Returns the list view of students
        }

        // GET: Students/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor); // Returns the details view of a specific student
        }

        // GET: Students/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new student
        }

        // POST: Students/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the student list
            }
            return View(donor);
        }

        // GET: Students/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor); // Returns the edit view for a specific student
        }

        // POST: Students/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Donor donor)
        {
            if (id != donor.DonorID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the student list
            }
            return View(donor);
        }

        // GET: Students/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor); // Returns the delete confirmation view
        }

        // POST: Students/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the student list
        }

        private bool DonorExists(int id)
        {
            return _context.Donors.Any(e => e.DonorID == id);
        }
    }
}
