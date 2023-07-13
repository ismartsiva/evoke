using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using medicalproject.Models;

namespace medicalproject.Controllers
{
    public class PatientTablesController : Controller
    {
        private readonly MedicaldbContext _context;

        public PatientTablesController(MedicaldbContext context)
        {
            _context = context;
        }

        // GET: PatientTables
        public async Task<IActionResult> Index()
        {
            var medicaldbContext = _context.PatientTables.Include(p => p.DoctorTypeNavigation);
            return View(await medicaldbContext.ToListAsync());
        }

        // GET: PatientTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientTables == null)
            {
                return NotFound();
            }

            var patientTable = await _context.PatientTables
                .Include(p => p.DoctorTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientTable == null)
            {
                return NotFound();
            }

            return View(patientTable);
        }

        // GET: PatientTables/Create
        public IActionResult Create()
        {
            ViewData["DoctorType"] = new SelectList(_context.DoctorTables, "DoctorType", "DoctorType");
            return View();
        }

        // POST: PatientTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,PhoneNo,DoctorType")] PatientTable patientTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorType"] = new SelectList(_context.DoctorTables, "DoctorType", "DoctorType", patientTable.DoctorType);
            return View(patientTable);
        }

        // GET: PatientTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientTables == null)
            {
                return NotFound();
            }

            var patientTable = await _context.PatientTables.FindAsync(id);
            if (patientTable == null)
            {
                return NotFound();
            }
            ViewData["DoctorType"] = new SelectList(_context.DoctorTables, "DoctorType", "DoctorType", patientTable.DoctorType);
            return View(patientTable);
        }

        // POST: PatientTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,PhoneNo,DoctorType")] PatientTable patientTable)
        {
            if (id != patientTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientTableExists(patientTable.Id))
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
            ViewData["DoctorType"] = new SelectList(_context.DoctorTables, "DoctorType", "DoctorType", patientTable.DoctorType);
            return View(patientTable);
        }

        // GET: PatientTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientTables == null)
            {
                return NotFound();
            }

            var patientTable = await _context.PatientTables
                .Include(p => p.DoctorTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientTable == null)
            {
                return NotFound();
            }

            return View(patientTable);
        }

        // POST: PatientTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientTables == null)
            {
                return Problem("Entity set 'MedicaldbContext.PatientTables'  is null.");
            }
            var patientTable = await _context.PatientTables.FindAsync(id);
            if (patientTable != null)
            {
                _context.PatientTables.Remove(patientTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientTableExists(int id)
        {
          return (_context.PatientTables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
