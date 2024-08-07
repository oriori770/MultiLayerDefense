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
    public class ResponsesController : Controller
    {
        private readonly Multi_Layer_DefenseContext _context;

        public ResponsesController(Multi_Layer_DefenseContext context)
        {
            _context = context;
        }

        // GET: Responses
        public async Task<IActionResult> Index()
        {
            var multi_Layer_DefenseContext = _context.Response.Include(r => r.Interceptor).Include(r => r.Threat);
            return View(await multi_Layer_DefenseContext.ToListAsync());
        }

        // GET: Responses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Response
                .Include(r => r.Interceptor)
                .Include(r => r.Threat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Responses/Create
        public IActionResult Create()
        {
            ViewData["InterceptorId"] = new SelectList(_context.Interceptor, "Id", "Id");
            ViewData["ThreatId"] = new SelectList(_context.Threat, "Id", "Origin");
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ThreatId,LaunchTime,InterceptTime,InterceptorId,status")] Response response)
        {
            if (ModelState.IsValid)
            {
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterceptorId"] = new SelectList(_context.Interceptor, "Id", "Id", response.InterceptorId);
            ViewData["ThreatId"] = new SelectList(_context.Threat, "Id", "Origin", response.ThreatId);
            return View(response);
        }

        // GET: Responses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Response.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            ViewData["InterceptorId"] = new SelectList(_context.Interceptor, "Id", "Id", response.InterceptorId);
            ViewData["ThreatId"] = new SelectList(_context.Threat, "Id", "Origin", response.ThreatId);
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ThreatId,LaunchTime,InterceptTime,InterceptorId,status")] Response response)
        {
            if (id != response.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseExists(response.Id))
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
            ViewData["InterceptorId"] = new SelectList(_context.Interceptor, "Id", "Id", response.InterceptorId);
            ViewData["ThreatId"] = new SelectList(_context.Threat, "Id", "Origin", response.ThreatId);
            return View(response);
        }

        // GET: Responses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Response
                .Include(r => r.Interceptor)
                .Include(r => r.Threat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Response.FindAsync(id);
            if (response != null)
            {
                _context.Response.Remove(response);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponseExists(int id)
        {
            return _context.Response.Any(e => e.Id == id);
        }
    }
}
