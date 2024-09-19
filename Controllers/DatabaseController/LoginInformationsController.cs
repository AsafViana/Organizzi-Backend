using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organizzi.Models;

namespace Organizzi.Controllers.DatabaseController
{
    public class LoginInformationsController : Controller
    {
        private readonly Context _context;

        public LoginInformationsController(Context context)
        {
            _context = context;
        }

        // GET: LoginInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginInformations.ToListAsync());
        }

        // GET: LoginInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginInformations = await _context.LoginInformations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loginInformations == null)
            {
                return NotFound();
            }

            return View(loginInformations);
        }

        // GET: LoginInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,DetailsID,Type")] LoginInformations loginInformations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginInformations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginInformations);
        }

        // GET: LoginInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginInformations = await _context.LoginInformations.FindAsync(id);
            if (loginInformations == null)
            {
                return NotFound();
            }
            return View(loginInformations);
        }

        // POST: LoginInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,DetailsID,Type")] LoginInformations loginInformations)
        {
            if (id != loginInformations.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginInformations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginInformationsExists(loginInformations.ID))
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
            return View(loginInformations);
        }

        // GET: LoginInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginInformations = await _context.LoginInformations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loginInformations == null)
            {
                return NotFound();
            }

            return View(loginInformations);
        }

        // POST: LoginInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginInformations = await _context.LoginInformations.FindAsync(id);
            if (loginInformations != null)
            {
                _context.LoginInformations.Remove(loginInformations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginInformationsExists(int id)
        {
            return _context.LoginInformations.Any(e => e.ID == id);
        }
    }
}
