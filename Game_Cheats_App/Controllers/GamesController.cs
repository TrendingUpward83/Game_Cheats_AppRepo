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
    public class GamesController : Controller
    {
        private readonly GameCheatsDbContext _context;

        public GamesController(GameCheatsDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var gameCheatsDbContext = _context.Games.Include(g => g.Platform);
            return View(await gameCheatsDbContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,GameName,PlatformId")] Games games)
        {
            if (ModelState.IsValid)
            {
                _context.Add(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", games.PlatformId);
            return View(games);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", games.PlatformId);
            return View(games);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,GameName,PlatformId")] Games games)
        {
            if (id != games.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.GameId))
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
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "PlatformId", "PlatformId", games.PlatformId);
            return View(games);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Games == null)
            {
                return Problem("Entity set 'GameCheatsDbContext.Games'  is null.");
            }
            var games = await _context.Games.FindAsync(id);
            if (games != null)
            {
                _context.Games.Remove(games);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesExists(int id)
        {
          return _context.Games.Any(e => e.GameId == id);
        }
    }
}
