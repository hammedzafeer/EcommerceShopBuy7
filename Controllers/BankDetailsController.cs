using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Data;
using ShopBuy7.Models;

namespace ShopBuy7.Controllers
{
    public class BankDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BankDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BankDetails
        public async Task<IActionResult> Index(int uid, char type)
        {
            if(uid > 0)
                return View(await _context.BankDetails.Where(x => !x.IsDeleted && x.UserType == type && x.UserId == uid).ToListAsync());
            else
                return View(await _context.BankDetails.ToListAsync());
        }

        // GET: BankDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(BankDetail bankDetail)
        {
            _context.Add(bankDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new {uid = bankDetail.UserId, type = bankDetail.UserType});
        }

        // GET: BankDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BankDetails == null)
            {
                return NotFound();
            }

            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail == null)
            {
                return NotFound();
            }
            return View(bankDetail);
        }

        // POST: BankDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankDetail bankDetail)
        {
            try
            {
                _context.Update(bankDetail);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankDetailExists(bankDetail.BankDetailId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", new { uid = bankDetail.UserId, type = bankDetail.UserType });

        }

        // POST: BankDetails/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.BankDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BankDetails'  is null.");
            }
            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail != null)
            {
                bankDetail.IsDeleted = !bankDetail.IsDeleted;
                _context.BankDetails.Update(bankDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { uid = bankDetail.UserId, type = bankDetail.UserType });

        }

        private bool BankDetailExists(int id)
        {
          return _context.BankDetails.Any(e => e.BankDetailId == id);
        }
    }
}
