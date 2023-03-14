using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Data;
using ShopBuy7.Models;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace ShopBuy7.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _host;

        public ProductsController(ApplicationDbContext _context, IWebHostEnvironment host)
        {
            context = _context;
            _host = host;
        }


        // GET: Products
        public async Task<IActionResult> Index()
        {
              return View(await context.Products.Where(x => !x.IsDeleted).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var product = await context.Products.FindAsync(id);
            if(product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Product product, List<IFormFile> files)
        {
            product.IsActive = true;
            product.IsDeleted = false;
            product.DateAdded = Global.SetDateTime();
            product.ImgUrl = "NotFound.png";
            context.Products.Add(product);
            await context.SaveChangesAsync();

            if(product.MyImage != null)
                product.ImgUrl = UploadMainImg(product.MyImage,product.ImgUrl, product.FkCustomerId, product.ProductId);
            if(files != null && files.Count > 0)
            {
                foreach(var file in files)
                {
                    UploadGallaryImg(file, product.FkCustomerId, product.ProductId);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Products == null)
            {
                return NotFound();
            }

            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.MyImage != null)
                        product.ImgUrl = UploadMainImg(product.MyImage, product.ImgUrl, product.FkCustomerId, product.ProductId);

                    context.Update(product);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }


        // POST: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = !product.IsDeleted;
                context.Products.Update(product);
            }
            
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return context.Products.Any(e => e.ProductId == id);
        }

        [HttpPost]
        public string UploadMainImg(IFormFile file, string name, int cid, int pid)
        {
            string rootPath = _host.WebRootPath;
            string ImgFolder = rootPath + "/Images/Products/" + cid;
            // If directory does not exist, create it. 
            if (!Directory.Exists(ImgFolder))
            {
                Directory.CreateDirectory(ImgFolder);
            }
            if (name != "NotFound.png")
            {
                //var imagePath = Path.Combine(Global.liveImgPath + "Products/" +  productId + "/" + product.ImgUrl);
                var imagePath = Path.Combine(ImgFolder + "/" + name);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            //string FileName = Path.GetFileNameWithoutExtension(file.FileName);
            string FileExtension = Path.GetExtension(file.FileName);
            string fileName = pid+"-p-" + DateTime.Now.ToString("yymmssfff") + FileExtension;
            string path = Path.Combine(ImgFolder+ "/", fileName);

            //var filePath = Path.Combine("D:\\Office Projects\\Git Projects\\RestaurantStaff\\RestaurantStaff\\HomeHealthCare\\wwwroot\\images\\banners", file.FileName);
            using (var imageStream = new MemoryStream())
            {
                file.CopyTo(imageStream);
                imageStream.Seek(0, SeekOrigin.Begin);

                using (var output = new MemoryStream())
                using (var image = Image.Load(imageStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(800, 800),
                        Mode = ResizeMode.Max
                    }));

                    image.Save(path, new JpegEncoder());

                    return fileName;
                }
            }
        }
        [HttpPost]
        public void UploadGallaryImg(IFormFile file, int cid, int pid)
        {
            string rootPath = _host.WebRootPath;
            string ImgFolder = rootPath + "/Images/Products/" + cid;
            // If directory does not exist, create it. 
            if (!Directory.Exists(ImgFolder))
            {
                Directory.CreateDirectory(ImgFolder);
            }
            //string FileName = Path.GetFileNameWithoutExtension(file.FileName);
            string FileExtension = Path.GetExtension(file.FileName);
            string fileName = pid+"-s-" + DateTime.Now.ToString("yymmssfff") + FileExtension;
            string path = Path.Combine(ImgFolder+ "/", fileName);

            //var filePath = Path.Combine("D:\\Office Projects\\Git Projects\\RestaurantStaff\\RestaurantStaff\\HomeHealthCare\\wwwroot\\images\\banners", file.FileName);
            using (var imageStream = new MemoryStream())
            {
                file.CopyTo(imageStream);
                imageStream.Seek(0, SeekOrigin.Begin);

                using (var output = new MemoryStream())
                using (var image = Image.Load(imageStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(800, 800),
                        Mode = ResizeMode.Max
                    }));

                    image.Save(path, new JpegEncoder());

                    ImageModel img = new()
                    {
                        FkProductId = pid,
                        ImgUrl = fileName
                    };

                    context.Images.Add(img);
                    context.SaveChanges();
                }
            }
        }


    }
}
