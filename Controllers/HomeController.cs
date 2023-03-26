using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBuy7.Data;
using ShopBuy7.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;

namespace ShopBuy7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        public HomeController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            HomeModel model = new();
            model.Products = context.Products.OrderByDescending(x => x.ProductId).Where(x => x.IsActive && !x.IsDeleted).Take(10).ToList();
            model.Products = getCatName(model.Products);
            model.Featured = context.Products.OrderByDescending(x => x.ProductId).Where(x => x.IsActive && !x.IsDeleted && x.IsFeatured).Take(10).ToList();
            model.Featured = getCatName(model.Featured);
            model.OnSale = context.Products.OrderByDescending(x => x.ProductId).Where(x => x.IsActive && !x.IsDeleted && x.SalePrice < x.MarkedPrice).Take(10).ToList();
            model.OnSale = getCatName(model.OnSale);
            model.TopRated = context.Products.OrderByDescending(x => x.ProductId).Where(x => x.IsActive && !x.IsDeleted).Take(10).ToList();
            model.TopRated = getCatName(model.TopRated);
            model.Banners = context.Banners.OrderByDescending(x => x.BannerId).Where(x => x.IsActive).ToList();
            Global.Categories = model.Categories = context.Categories.OrderBy(x => x.Name).Where(x => !x.IsDeleted).ToList();
            Global.SubCategories = model.SubCategories = context.SubCategories.OrderBy(x => x.Name).Where(x => !x.IsDeleted).ToList();
            model.Deals = context.Deals.OrderByDescending(x => x.DealId).Where(x => x.ExpiryDateTime > Global.SetDateTime()).ToList();
            foreach(var d in model.Deals)
            {
                var product = context.Products.Find(d.FkProductId);
                d.Images = context.Images.Where(x => x.FkProductId == d.FkProductId).ToList();
                if (product != null)
                    d.Product = product;
                d.RemainingTime = d.ExpiryDateTime - Global.SetDateTime();
                var orderDetails = (from orderDetail in context.OrderDetails
                                   join order in context.Orders
                                   on orderDetail.FkOrderId equals order.OrderId
                                   into od
                                   from allOrders in od.DefaultIfEmpty()
                                   where
                                   orderDetail.FkProductId == d.FkProductId
                                   && allOrders.DateAdded >= d.DateAdded
                                   select orderDetail).ToList();
                d.Sold = orderDetails.Sum(x => x.Quantity);                
            }
            return View(model);
        }

        public List<Product> getCatName(List<Product> products)
        {
            var subcats = context.SubCategories.Where(x => !x.IsDeleted).ToList();
            foreach(var p in products)
            {
                var cat = subcats.FirstOrDefault(x => x.SubCategoryId == p.FkSubCategoryId); 
                if(cat != null)
                {
                    p.CatName = cat.Name;
                }
                else
                {
                    p.CatName = "Unkown";
                }
            }
            return products;
        }

        public IActionResult my_account()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string username, string password)
        {
            var user = await context.Authentications.FirstOrDefaultAsync(u => (u.AuthenticationId.ToString() == username || u.UserName == username.ToString().ToLower()) && u.Password == password);
            if (user != null)
            {
                //Customer Log In
                if (user.UserType == 'c')
                {
                    var customer = context.Customers.Find(user.FkUserId);
                    if (customer != null)
                    {
                        if (customer.IsActive)
                        {
                            var claims = new List<Claim>
                            {
                                new Claim("name", customer.FName + " " + customer.LName),
                                new Claim("usertype", "Customer"),
                                new Claim(ClaimTypes.NameIdentifier, username.ToLower()),
                                new Claim(ClaimTypes.Name, "Customer")
                            };
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                            AuthenticationLog userLog = new();
                            userLog.FkUserId = customer.CustomerId;
                            userLog.UserType = 'c';

                            context.UserLogs.Add(userLog);
                            await context.SaveChangesAsync();
                            HttpContext.Session.SetString("name", customer.FName + " " + customer.LName);
                            HttpContext.Session.SetString("userid", customer.CustomerId.ToString());
                            return RedirectToAction("UserDashboard", "Home");
                        }
                        ViewBag.Error = "You are not an Active User, Please Contact with Administration";
                        return View();
                    }
                    ViewBag.Error = "Customer Not Found";
                    return View();
                }
                //Employee Log In
                if (user.UserType == 'e')
                {
                    var employee = context.Employees.Find(user.FkUserId);
                    if (employee != null)
                    {
                        if (employee.IsActive)
                        {
                            var claims = new List<Claim>
                            {
                                new Claim("userid", employee.EmpId.ToString()),
                                new Claim("name", employee.Name),
                                new Claim("usertype", "Employee"),
                                new Claim(ClaimTypes.NameIdentifier, username.ToLower()),
                                new Claim(ClaimTypes.Name, "Employee")
                            };
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                            AuthenticationLog userLog = new();
                            userLog.FkUserId = employee.EmpId;
                            userLog.UserType = 'e';

                            context.UserLogs.Add(userLog);
                            await context.SaveChangesAsync();
                            HttpContext.Session.SetString("name", employee.Name);
                            HttpContext.Session.SetString("userid", employee.EmpId.ToString());
                            return RedirectToAction("UserDashboard", "Home");
                        }
                        ViewBag.Error = "You are not an Active User, Please Contact with Administration";
                        return View();
                    }
                    ViewBag.Error = "Employee Not Found";
                    return View();
                }
            }
            ViewBag.Error = "User Not Found";
            return View();
        }

        [Authorize]
        public IActionResult UserDashboard()
        {
            if (User.Claims.FirstOrDefault(c => c.Type == "userid").Value == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                string c = "Customer";
                foreach (Claim claim in User.Claims)
                {
                    if (claim.Value.Contains("Customer"))
                    {
                        c = "Customer";
                        break;
                    }
                    else if (claim.Value.Contains("Employee"))
                    {
                        c = "Employee";
                    }                    
                }
                string Action = "";
                string Controller = "";
                switch (c)
                {
                    case "Customer":
                        Action = "CustomerDashboard";
                        Controller = "Customers";
                        break;
                    case "Employee":
                        Action = "EmployeeDashboard";
                        Controller = "Employees";
                        break;                   
                }
                return RedirectToAction(Action, Controller);
            }
        }



        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
            return Redirect("/");
        }

        [HttpPost]
        public JsonResult SearchProduct(string prefix)
        {
            var searchs = (from search in context.Products
                           where search.Name.Contains(prefix)
                           select new
                           {
                               label = search.Name,
                           }).Take(7).ToList();

            return Json(searchs);
        }

        [HttpPost]
        public JsonResult EmailVerfication(string email)
        {
            int random = new Random().Next(1000, 9999);
            try
            {
                Global.EmailVerification(email, "Verification Code", random.ToString());
            }
            catch
            {

            }
            return Json(random);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}