using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Game_Cheats_App.Data;
using Game_Cheats_App.Models;

namespace Game_Cheats_App.Controllers
{
    public class CheatsController : Controller
    {
        private readonly GameCheatsDbContext _context;

        public CheatsController(GameCheatsDbContext context)
        {
            _context = context;
        }

        // GET: Cheats
        public async Task<IActionResult> Index()
        {
            var gameCheatsDbContext = _context.Cheats.Include(c => c.Game);
            return View(await gameCheatsDbContext.ToListAsync());
        }

        // GET: Cheats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cheats == null)
            {
                return NotFound();
            }

            var cheats = await _context.Cheats
                .Include(c => c.Game)
                .FirstOrDefaultAsync(m => m.CheatId == id);
            if (cheats == null)
            {
                return NotFound();
            }

            return View(cheats);
        }

        // GET: Cheats/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            return View();
        }

        // POST: Cheats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheatId,CheatName,GameId")] Cheats cheats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", cheats.GameId);
            return View(cheats);
        }

        // GET: Cheats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cheats == null)
            {
                return NotFound();
            }

            var cheats = await _context.Cheats.FindAsync(id);
            if (cheats == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", cheats.GameId);
            return View(cheats);
        }

        // POST: Cheats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheatId,CheatName,GameId")] Cheats cheats)
        {
            if (id != cheats.CheatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheatsExists(cheats.CheatId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", cheats.GameId);
            return View(cheats);
        }

        // GET: Cheats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cheats == null)
            {
                return NotFound();
            }

            var cheats = await _context.Cheats
                .Include(c => c.Game)
                .FirstOrDefaultAsync(m => m.CheatId == id);
            if (cheats == null)
            {
                return NotFound();
            }

            return View(cheats);
        }

        // POST: Cheats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cheats == null)
            {
                return Problem("Entity set 'GameCheatsDbContext.Cheats'  is null.");
            }
            var cheats = await _context.Cheats.FindAsync(id);
            if (cheats != null)
            {
                _context.Cheats.Remove(cheats);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheatsExists(int id)
        {
          return _context.Cheats.Any(e => e.CheatId == id);
        }
    }
}
