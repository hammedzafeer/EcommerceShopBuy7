using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Data;
using ShopBuy7.Models;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ShopBuy7.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _host;

        public CategoriesController(ApplicationDbContext _context, IWebHostEnvironment host)
        {
            context = _context;
            _host = host;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              return View(await context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Categories == null)
            {
                return NotFound();
            }

            var category = await context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
            if(category.MyImage != null)
                    category.ImgUrl = Global.UploadMainImg(_host,category.MyImage, category.ImgUrl, category.CategoryId,'c');
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Categories == null)
            {
                return NotFound();
            }

            var category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            try
            {
                if (category.MyImage != null)
                    category.ImgUrl = Global.UploadMainImg(_host,category.MyImage, category.ImgUrl, category.CategoryId,'c');
                context.Update(category);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return View(category);
            }
            return RedirectToAction(nameof(Index));
        }
       

        // POST: Categories/Delete/5       
        public async Task<IActionResult> Delete(int id)
        {
            if (context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                category.IsDeleted = !category.IsDeleted;
                context.Categories.Update(category);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return context.Categories.Any(e => e.CategoryId == id);
        }

    }
}
