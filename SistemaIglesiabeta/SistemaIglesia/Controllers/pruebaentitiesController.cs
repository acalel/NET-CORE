using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaIglesia.Datos;
using SistemaIglesia.Models;

namespace SistemaIglesia.Controllers
{
    public class pruebaentitiesController : Controller
    {
        private readonly MvcMovieContext _context;

        public pruebaentitiesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: pruebaentities
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            return View(await _context.Movie.ToListAsync());
        }

        // GET: pruebaentities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pruebaentity = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pruebaentity == null)
            {
                return NotFound();
            }

            return View(pruebaentity);
        }

        // GET: pruebaentities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pruebaentities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] pruebaentity pruebaentity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pruebaentity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pruebaentity);
        }

        // GET: pruebaentities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pruebaentity = await _context.Movie.FindAsync(id);
            if (pruebaentity == null)
            {
                return NotFound();
            }
            return View(pruebaentity);
        }

        // POST: pruebaentities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] pruebaentity pruebaentity)
        {
            if (id != pruebaentity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pruebaentity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pruebaentityExists(pruebaentity.Id))
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
            return View(pruebaentity);
        }

        // GET: pruebaentities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pruebaentity = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pruebaentity == null)
            {
                return NotFound();
            }

            return View(pruebaentity);
        }

        // POST: pruebaentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pruebaentity = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(pruebaentity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pruebaentityExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
