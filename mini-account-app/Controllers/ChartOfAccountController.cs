using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini_account_app.Data;
using mini_account_app.Models;

namespace mini_account_app.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChartOfAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChartOfAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChartOfAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChartOfAccounts.ToListAsync());
        }

        // GET: ChartOfAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chartOfAccounts = await _context.ChartOfAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            return View(chartOfAccounts);
        }

        // GET: ChartOfAccount/Create
        public IActionResult Create()
        {
            ViewBag.lstAccountType = ChartOfAccountsType.lstAccountType.Select(_ => new SelectListItem()
            { Value = _, Text = _ });

            return View();
        }

        // POST: ChartOfAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountType,AccountName")] ChartOfAccounts chartOfAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chartOfAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chartOfAccounts);
        }

        // GET: ChartOfAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chartOfAccounts = await _context.ChartOfAccounts.FindAsync(id);
            if (chartOfAccounts == null)
            {
                return NotFound();
            }
            return View(chartOfAccounts);
        }

        // POST: ChartOfAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountType,AccountName")] ChartOfAccounts chartOfAccounts)
        {
            if (id != chartOfAccounts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chartOfAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChartOfAccountsExists(chartOfAccounts.Id))
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
            return View(chartOfAccounts);
        }

        // GET: ChartOfAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chartOfAccounts = await _context.ChartOfAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chartOfAccounts == null)
            {
                return NotFound();
            }

            return View(chartOfAccounts);
        }

        // POST: ChartOfAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chartOfAccounts = await _context.ChartOfAccounts.FindAsync(id);
            if (chartOfAccounts != null)
            {
                _context.ChartOfAccounts.Remove(chartOfAccounts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChartOfAccountsExists(int id)
        {
            return _context.ChartOfAccounts.Any(e => e.Id == id);
        }
    }
}
