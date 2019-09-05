using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMerchTracker.Data;
using MyMerchTracker.Models;

namespace MyMerchTracker.Controllers
{
    public class MerchsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerchsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Merchs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merch.ToListAsync());
        }

        // GET: Merchs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merch = await _context.Merch
                .FirstOrDefaultAsync(m => m.MerchId == id);
            if (merch == null)
            {
                return NotFound();
            }

            return View(merch);
        }

        // GET: Merchs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerchId,Description,Quantity,UserId,MerchTypeId")] Merch merch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merch);
        }

        // GET: Merchs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merch = await _context.Merch.FindAsync(id);
            if (merch == null)
            {
                return NotFound();
            }
            return View(merch);
        }

        // POST: Merchs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MerchId,Description,Quantity,UserId,MerchTypeId")] Merch merch)
        {
            if (id != merch.MerchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchExists(merch.MerchId))
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
            return View(merch);
        }

        // GET: Merchs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merch = await _context.Merch
                .FirstOrDefaultAsync(m => m.MerchId == id);
            if (merch == null)
            {
                return NotFound();
            }

            return View(merch);
        }

        // POST: Merchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merch = await _context.Merch.FindAsync(id);
            _context.Merch.Remove(merch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchExists(int id)
        {
            return _context.Merch.Any(e => e.MerchId == id);
        }
    }
}
