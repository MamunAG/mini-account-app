using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini_account_app.Data;
using mini_account_app.Models;

namespace mini_account_app.Controllers
{
    public class VoucherEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoucherEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VoucherEntry
        public async Task<IActionResult> Index()
        {
            return View(await _context.VoucherEntry.ToListAsync());
        }

        // GET: VoucherEntry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucherEntry = await _context.VoucherEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucherEntry == null)
            {
                return NotFound();
            }

            return View(voucherEntry);
        }

        // GET: VoucherEntry/Create
        public IActionResult Create()
        {
            ViewBag.lstVoucherType = VoucherType.lstVoucherType.Select(_ => new SelectListItem()
            { Value = _, Text = _ });

            return View();
        }

        // POST: VoucherEntry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoucherNo,VoucherType,VoucherDate,ReferenceNo")] VoucherEntry voucherEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voucherEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voucherEntry);
        }

        // GET: VoucherEntry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucherEntry = await _context.VoucherEntry.FindAsync(id);
            if (voucherEntry == null)
            {
                return NotFound();
            }
            return View(voucherEntry);
        }

        // POST: VoucherEntry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoucherNo,VoucherType,VoucherDate,ReferenceNo")] VoucherEntry voucherEntry)
        {
            if (id != voucherEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voucherEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoucherEntryExists(voucherEntry.Id))
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
            return View(voucherEntry);
        }

        // GET: VoucherEntry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucherEntry = await _context.VoucherEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucherEntry == null)
            {
                return NotFound();
            }

            return View(voucherEntry);
        }

        // POST: VoucherEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voucherEntry = await _context.VoucherEntry.FindAsync(id);
            if (voucherEntry != null)
            {
                _context.VoucherEntry.Remove(voucherEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoucherEntryExists(int id)
        {
            return _context.VoucherEntry.Any(e => e.Id == id);
        }
    }
}
