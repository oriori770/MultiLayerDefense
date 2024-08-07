using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multi_Layer_Defense.Data;
using Multi_Layer_Defense.Models;

namespace Multi_Layer_Defense.Controllers
{
    public class ThreatsController : Controller
    {
        private readonly Multi_Layer_DefenseContext _context;

        public ThreatsController(Multi_Layer_DefenseContext context)
        {
            _context = context;
        }

        // GET: Threats
        public async Task<IActionResult> Index()
        {
            var multi_Layer_DefenseContext = _context.Threat.Include(t => t.Weapon);
            return View(await multi_Layer_DefenseContext.ToListAsync());
        }

        // GET: Threats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.Threat
                .Include(t => t.Weapon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }

        // GET: Threats/Create
        public IActionResult Create()
        {
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "Id");
            return View();
        }

        // POST: Threats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Origin,LaunchTime,WeaponId")] Threat threat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "Id", threat.WeaponId);
            return View(threat);
        }

        // GET: Threats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.Threat.FindAsync(id);
            if (threat == null)
            {
                return NotFound();
            }
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "Id", threat.WeaponId);
            return View(threat);
        }

        // POST: Threats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origin,LaunchTime,WeaponId")] Threat threat)
        {
            if (id != threat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreatExists(threat.Id))
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
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "Id", "Id", threat.WeaponId);
            return View(threat);
        }

        // GET: Threats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.Threat
                .Include(t => t.Weapon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }

        // POST: Threats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threat = await _context.Threat.FindAsync(id);
            if (threat != null)
            {
                _context.Threat.Remove(threat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreatExists(int id)
        {
            return _context.Threat.Any(e => e.Id == id);
        }
    }
}
