using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Data;
using ShopBuy7.Models;

namespace ShopBuy7.Controllers
{
    public class RanksController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _host;

        public RanksController(ApplicationDbContext _context, IWebHostEnvironment host)
        {
            context = _context;
            _host = host;
        }

        // GET: Ranks
        public async Task<IActionResult> Index()
        {
              return View(await context.Ranks.ToListAsync());
        }

        // GET: Ranks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Ranks == null)
            {
                return NotFound();
            }

            var rank = await context.Ranks
                .FirstOrDefaultAsync(m => m.RankId == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // GET: Ranks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ranks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Rank rank)
        {
            rank.ImgUrl = "NotFound.png";
            rank.GiftImgUrl = "NotFound.png";
            context.Add(rank);
            await context.SaveChangesAsync();
            if(rank.MyImage != null)
            {
                rank.ImgUrl = Global.UploadMainImg(_host, rank.MyImage, rank.ImgUrl, rank.RankId, 'r');
            }
            if (rank.GiftImage != null)
            {
                rank.GiftImgUrl = Global.UploadMainImg(_host, rank.GiftImage, rank.GiftImgUrl, rank.RankId, 'r');
            }
            context.Ranks.Update(rank);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Ranks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Ranks == null)
            {
                return NotFound();
            }

            var rank = await context.Ranks.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }
            return View(rank);
        }

        // POST: Ranks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Rank rank)
        {
            try
            {
                if (rank.MyImage != null)
                {
                    rank.ImgUrl = Global.UploadMainImg(_host, rank.MyImage, rank.ImgUrl, rank.RankId, 'r');
                }
                if (rank.GiftImage != null)
                {
                    rank.GiftImgUrl = Global.UploadMainImg(_host, rank.GiftImage, rank.GiftImgUrl, rank.RankId, 'r');
                }
                context.Ranks.Update(rank);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankExists(rank.RankId))
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

        // GET: Ranks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Ranks == null)
            {
                return NotFound();
            }

            var rank = await context.Ranks
                .FirstOrDefaultAsync(m => m.RankId == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // POST: Ranks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Ranks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ranks'  is null.");
            }
            var rank = await context.Ranks.FindAsync(id);
            if (rank != null)
            {
                context.Ranks.Remove(rank);
            }
            
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankExists(int id)
        {
          return context.Ranks.Any(e => e.RankId == id);
        }
    }
}
