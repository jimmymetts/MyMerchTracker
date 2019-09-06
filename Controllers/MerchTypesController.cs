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
    public class MerchTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerchTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MerchTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MerchType.ToListAsync());
        }

        // GET: MerchTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchType = await _context.MerchType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchType == null)
            {
                return NotFound();
            }

            return View(merchType);
        }

        // GET: MerchTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MerchTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,label")] MerchType merchType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchType);
        }

        // GET: MerchTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchType = await _context.MerchType.FindAsync(id);
            if (merchType == null)
            {
                return NotFound();
            }
            return View(merchType);
        }

        // POST: MerchTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,label")] MerchType merchType)
        {
            if (id != merchType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchTypeExists(merchType.Id))
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
            return View(merchType);
        }

        // GET: MerchTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchType = await _context.MerchType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merchType == null)
            {
                return NotFound();
            }

            return View(merchType);
        }

        // POST: MerchTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchType = await _context.MerchType.FindAsync(id);
            _context.MerchType.Remove(merchType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchTypeExists(int id)
        {
            return _context.MerchType.Any(e => e.Id == id);
        }
    }
}
