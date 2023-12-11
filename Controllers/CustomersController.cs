using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodingCafeV2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace CodingCafeV2.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        
        private readonly CafeContext _context;

        public CustomersController(CafeContext context)
        {
            _context = context;
        }

        // GET: Customers
        //  [Authorize(Roles = "Administrator,Manager,User")]

        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var customers = from m in _context.Customers.Include(a => a.Menu)
                            select m;


            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StateSort = sortOrder == "State" ? "statedesc" : "state";


            if (_context.Customers == null)
            {
                return Problem("No Results");
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(m => m.FirstName.Contains(searchString)
            || m.LastName.Contains(searchString)
            || m.Address.Contains(searchString)
            || m.State.Contains(searchString)
            || m.City.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(m => m.FirstName);
                    break;
                case "state":
                    customers = customers.OrderBy(m => m.State);
                    break;
                case "statedesc":
                    customers = customers.OrderByDescending(m => m.State);
                    break;
                default:
                    customers = customers.OrderBy(m => m.FirstName);
                    break;
            }

            return View(await customers.ToListAsync());
        }

        // GET: Customers/Details/5
        //  [Authorize(Roles = "Administrator,Manager,User")]

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(a => a.Menu)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
       // [Authorize(Roles = "Administrator,Manager")]
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "Item");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Address,City,State,Zip,Email,Phone,MenuId")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "MenuId", customers.MenuId);

            return View(customers);
        }

        // GET: Customers/Edit/5
      //  [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "Item");
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Address,City,State,Zip,Email,Phone,MenuId")] Customers customers)
        {
            if (id != customers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.ID))
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
            ViewData["MenuId"] = new SelectList(_context.Menu, "MenuId", "MenuId", customers.MenuId);
            return View(customers);
        }

        // GET: Customers/Delete/5
      //  [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(a => a.Menu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       // [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'CafeContext.Customers'  is null.");
            }
            var customers = await _context.Customers.FindAsync(id);
            if (customers != null)
            {
                _context.Customers.Remove(customers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
          return (_context.Customers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
