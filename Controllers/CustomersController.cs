using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBuy7.Data;
using ShopBuy7.Models;

namespace ShopBuy7.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Create(Customer customer)
        {
            var cus = _context.Customers.FirstOrDefault(x => x.Email == customer.Email.ToLower().Trim());
            if(cus == null)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                var auth = new Authentication()
                {
                    UserName = customer.Email,
                    UserType = 'c',
                    FkUserId = customer.CustomerId
                };
                int random = new Random().Next(1000, 9999);
                auth.Password = random.ToString();

                _context.Authentications.Add(auth);
                _context.SaveChanges();
                try
                {
                    Global.EmailNotification(customer.Email, "Registered Successfully", "Welcome to shop buy 7");
                }
                catch
                {

                }

                return RedirectToAction("Home", "Index");
            }
            else
            {
                ///Error: email already registred...
                return RedirectToAction("Home", "Index");
            }
        }
       
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            try
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
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
        private bool CustomerExists(int id)
        {
          return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
