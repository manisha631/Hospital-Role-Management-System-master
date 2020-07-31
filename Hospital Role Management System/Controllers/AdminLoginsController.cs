using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Role_Management_System.Models;

namespace Hospital_Role_Management_System.Controllers
{
    public class AdminLoginsController : Controller
    {
        private readonly HSMdbContext _context;

        public AdminLoginsController(HSMdbContext context)
        {
            _context = context;
        }

        // GET: AdminLogins
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminLogin.ToListAsync());
        }

        // GET: AdminLogins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLogin = await _context.AdminLogin
                .FirstOrDefaultAsync(m => m.UserPassword == id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            return View(adminLogin);
        }

        // GET: AdminLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,UserPassword,UserType")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminLogin);
        }

        // GET: AdminLogins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLogin = await _context.AdminLogin.FindAsync(id);
            if (adminLogin == null)
            {
                return NotFound();
            }
            return View(adminLogin);
        }

        // POST: AdminLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,UserPassword,UserType")] AdminLogin adminLogin)
        {
            if (id != adminLogin.UserPassword)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminLoginExists(adminLogin.UserPassword))
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
            return View(adminLogin);
        }

        // GET: AdminLogins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLogin = await _context.AdminLogin
                .FirstOrDefaultAsync(m => m.UserPassword == id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            return View(adminLogin);
        }

        // POST: AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adminLogin = await _context.AdminLogin.FindAsync(id);
            _context.AdminLogin.Remove(adminLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminLoginExists(string id)
        {
            return _context.AdminLogin.Any(e => e.UserPassword == id);
        }
    }
}
