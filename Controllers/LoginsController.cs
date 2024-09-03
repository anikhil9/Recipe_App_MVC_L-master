using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recipe_App.Data;
using Recipe_App.Models;

/*namespace Recipe_App.Controllers
{
    public class LoginsController : Controller
    {
        private readonly Recipe_AppContext _context;

        public LoginsController(Recipe_AppContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
              return _context.Login != null ? 
                          View(await _context.Login.ToListAsync()) :
                          Problem("Entity set 'Recipe_AppContext.Login'  is null.");
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Password")] Login login)
        {
            if (id != login.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.Id))
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
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Login == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Login == null)
            {
                return Problem("Entity set 'Recipe_AppContext.Login'  is null.");
            }
            var login = await _context.Login.FindAsync(id);
            if (login != null)
            {
                _context.Login.Remove(login);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,Password")] Login login)
        {
            if (_context.Login == null)
            {
                return Problem("Entity set 'Recipe_AppContext.Login' is null.");
            }

            var user = await _context.Login
                                      .FirstOrDefaultAsync(m => m.Id == login.Id && m.Password == login.Password);
            if (user != null)
            {
                // Redirect to dashboard if login is successful
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(login);
            }
        }

        private bool LoginExists(string id)
        {
          return (_context.Login?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}*/

/*namespace Recipe_App.Controllers
{
    public class LoginsController : Controller
    {
        private readonly Recipe_AppContext _context;

        public LoginsController(Recipe_AppContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,Password")] Login login)
        {
            if (_context.Login == null)
            {
                return Problem("Entity set 'Recipe_AppContext.Login' is null.");
            }

            var user = await _context.Login
                .FirstOrDefaultAsync(u => u.Id == login.Id && u.Password == login.Password);

            if (user != null)
            {
                // Redirect to the dashboard if login is successful
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(login); // Return to the login view with an error message
            }
        }

        // GET method for Login view
        public IActionResult Login()
        {
            return View();
        }
    }
}*/

namespace Recipe_App.Controllers
{
    public class LoginsController : Controller
    {
        private readonly Recipe_AppContext _context;

        public LoginsController(Recipe_AppContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,Password")] Login login)
        {
            var user = await _context.Login.FirstOrDefaultAsync(m => m.Id == login.Id && m.Password == login.Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Id); // Storing username in session
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(login);
            }
        }


        // GET method for Login view
        public IActionResult Login()
        {
            return View();
        }
    }
}


