using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryTracker.Data;
using DeliveryTracker.Models;

namespace DeliveryTracker.Controllers
{
    public class OrderFullfillmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderFullfillmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderFullfillments
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderFullfillment.ToListAsync());
        }

        // GET: OrderFullfillments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFullfillment = await _context.OrderFullfillment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderFullfillment == null)
            {
                return NotFound();
            }

            return View(orderFullfillment);
        }

        // GET: OrderFullfillments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderFullfillments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,DeliveredBy,DeliveredTo,Status,Description")] OrderFullfillment orderFullfillment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderFullfillment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderFullfillment);
        }

        // GET: OrderFullfillments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFullfillment = await _context.OrderFullfillment.FindAsync(id);
            if (orderFullfillment == null)
            {
                return NotFound();
            }
            return View(orderFullfillment);
        }

        // POST: OrderFullfillments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,DeliveredBy,DeliveredTo,Status,Description")] OrderFullfillment orderFullfillment)
        {
            if (id != orderFullfillment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderFullfillment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderFullfillmentExists(orderFullfillment.Id))
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
            return View(orderFullfillment);
        }

        // GET: OrderFullfillments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFullfillment = await _context.OrderFullfillment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderFullfillment == null)
            {
                return NotFound();
            }

            return View(orderFullfillment);
        }

        // POST: OrderFullfillments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderFullfillment = await _context.OrderFullfillment.FindAsync(id);
            _context.OrderFullfillment.Remove(orderFullfillment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderFullfillmentExists(int id)
        {
            return _context.OrderFullfillment.Any(e => e.Id == id);
        }
    }
}
