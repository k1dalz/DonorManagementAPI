using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonorManagementAPI.Data;
using DonorManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonorManagementAPI.Controllers
{
    [Route("[controller]")]
    public class BloodBanksController : Controller
    {
        private readonly DonorManagementContext _context;

        public BloodBanksController(DonorManagementContext context)
        {
            _context = context;
        }

        // GET: Subjects
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bloodbank = await _context.BloodBanks.ToListAsync();
            return View(bloodbank); // Returns the list view of subjects
        }

        // GET: Subjects/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var bloodbank = await _context.BloodBanks.FindAsync(id);
            if (bloodbank == null)
            {
                return NotFound();
            }

            return View(bloodbank); // Returns the details view of a specific subject
        }

        // GET: Subjects/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new subject
        }

        // POST: Subjects/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BloodBanks bloodbank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodbank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the subject list
            }
            return View(bloodbank);
        }

        // GET: Subjects/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var bloodbank = await _context.BloodBanks.FindAsync(id);
            if (bloodbank == null)
            {
                return NotFound();
            }
            return View(bloodbank); // Returns the edit view for a specific subject
        }

        // POST: Subjects/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BloodBanks bloodbank)
        {
            if (id != bloodbank.BloodBankID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodbank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodBankExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the subject list
            }
            return View(bloodbank);
        }

        // GET: Subjects/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bloodbank = await _context.BloodBanks.FindAsync(id);
            if (bloodbank == null)
            {
                return NotFound();
            }

            return View(bloodbank); // Returns the delete confirmation view
        }

        // POST: Subjects/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodbank = await _context.BloodBanks.FindAsync(id);
            if (bloodbank != null)
            {
                _context.BloodBanks.Remove(bloodbank);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the subject list
        }

        private bool BloodBankExists(int id)
        {
            return _context.BloodBanks.Any(e => e.BloodBankID == id);
        }
    }
}
