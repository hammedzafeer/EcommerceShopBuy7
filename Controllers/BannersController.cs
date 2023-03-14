using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Data;
using ShopBuy7.Models;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ShopBuy7.Controllers
{
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _host;

        public BannersController(ApplicationDbContext _context, IWebHostEnvironment host)
        {
            context = _context;
            _host = host;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
              return View(await context.Banners.ToListAsync());
        }

        // GET: Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Banners == null)
            {
                return NotFound();
            }

            var banner = await context.Banners
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Banner banner)
        {
            context.Add(banner);
            await context.SaveChangesAsync();
            if (banner.MobileImage != null)
            {
                banner.MobileImgUrl = Global.UploadMainImg(_host, banner.MobileImage, banner.MobileImgUrl, banner.BannerId, 'b');
            }
            if (banner.WebImage != null)
            {
                banner.WebImgUrl = Global.UploadMainImg(_host, banner.WebImage, banner.WebImgUrl, banner.BannerId, 'b');
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Banners == null)
            {
                return NotFound();
            }

            var banner = await context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Banner banner)
        {
            try
            {
                if (banner.MobileImage != null)
                {
                    banner.MobileImgUrl = Global.UploadMainImg(_host,banner.MobileImage, banner.MobileImgUrl, banner.BannerId,'b');
                }
                if (banner.WebImage != null)
                {
                    banner.WebImgUrl = Global.UploadMainImg(_host, banner.WebImage, banner.WebImgUrl, banner.BannerId, 'b');
                }
                context.Update(banner);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return View(banner);
            }
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            if (context.Banners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Banners'  is null.");
            }
            var banner = await context.Banners.FindAsync(id);
            if (banner != null)
            {
                context.Banners.Remove(banner);
            }
            
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
          return context.Banners.Any(e => e.BannerId == id);
        }

        
    }
}
