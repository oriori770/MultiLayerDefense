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
    public class InterceptorsController : Controller
    {
        private readonly Multi_Layer_DefenseContext _context;

        public InterceptorsController(Multi_Layer_DefenseContext context)
        {
            _context = context;
        }

        // GET: Interceptors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interceptor.ToListAsync());
        }

        // GET: Interceptors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interceptor = await _context.Interceptor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interceptor == null)
            {
                return NotFound();
            }

            return View(interceptor);
        }

        // GET: Interceptors/Create
        public IActionResult Create()
        {
            var weaponTypes = Enum.GetValues(typeof(WeaponType))
                          .Cast<WeaponType>()
                          .Select(v => new SelectListItem
                          {
                              Text = v.ToString(),
                              Value = v.ToString()
                          }).ToList();

            ViewBag.Weapon = weaponTypes;
            var counterMeasureType = Enum.GetValues(typeof(CounterMeasureType))
              .Cast<CounterMeasureType>()
              .Select(v => new SelectListItem
              {
                  Text = v.ToString(),
                  Value = v.ToString()
              }).ToList();

            ViewBag.counterMeasure = counterMeasureType;
            return View();
        }

        // POST: Interceptors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,InterceptsThrough,ForType")] Interceptor interceptor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interceptor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interceptor);
        }

        // GET: Interceptors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interceptor = await _context.Interceptor.FindAsync(id);
            if (interceptor == null)
            {
                return NotFound();
            }
            return View(interceptor);
        }

        // POST: Interceptors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,InterceptsThrough,ForType")] Interceptor interceptor)
        {
            if (id != interceptor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interceptor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterceptorExists(interceptor.Id))
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
            return View(interceptor);
        }

        // GET: Interceptors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interceptor = await _context.Interceptor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interceptor == null)
            {
                return NotFound();
            }

            return View(interceptor);
        }

        // POST: Interceptors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interceptor = await _context.Interceptor.FindAsync(id);
            if (interceptor != null)
            {
                _context.Interceptor.Remove(interceptor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterceptorExists(int id)
        {
            return _context.Interceptor.Any(e => e.Id == id);
        }
    }
}
