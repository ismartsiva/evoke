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
    public class DoctorTablesController : Controller
    {
        private readonly MedicaldbContext _context;

        public DoctorTablesController(MedicaldbContext context)
        {
            _context = context;
        }

        // GET: DoctorTables
        public async Task<IActionResult> Index()
        {
              return _context.DoctorTables != null ? 
                          View(await _context.DoctorTables.ToListAsync()) :
                          Problem("Entity set 'MedicaldbContext.DoctorTables'  is null.");
        }

        // GET: DoctorTables/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DoctorTables == null)
            {
                return NotFound();
            }

            var doctorTable = await _context.DoctorTables
                .FirstOrDefaultAsync(m => m.DoctorType == id);
            if (doctorTable == null)
            {
                return NotFound();
            }

            return View(doctorTable);
        }

        // GET: DoctorTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorType,TypeOfMedicines")] DoctorTable doctorTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorTable);
        }

        // GET: DoctorTables/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DoctorTables == null)
            {
                return NotFound();
            }

            var doctorTable = await _context.DoctorTables.FindAsync(id);
            if (doctorTable == null)
            {
                return NotFound();
            }
            return View(doctorTable);
        }

        // POST: DoctorTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DoctorType,TypeOfMedicines")] DoctorTable doctorTable)
        {
            if (id != doctorTable.DoctorType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorTableExists(doctorTable.DoctorType))
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
            return View(doctorTable);
        }

        // GET: DoctorTables/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DoctorTables == null)
            {
                return NotFound();
            }

            var doctorTable = await _context.DoctorTables
                .FirstOrDefaultAsync(m => m.DoctorType == id);
            if (doctorTable == null)
            {
                return NotFound();
            }

            return View(doctorTable);
        }

        // POST: DoctorTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DoctorTables == null)
            {
                return Problem("Entity set 'MedicaldbContext.DoctorTables'  is null.");
            }
            var doctorTable = await _context.DoctorTables.FindAsync(id);
            if (doctorTable != null)
            {
                _context.DoctorTables.Remove(doctorTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorTableExists(string id)
        {
          return (_context.DoctorTables?.Any(e => e.DoctorType == id)).GetValueOrDefault();
        }
    }
}
