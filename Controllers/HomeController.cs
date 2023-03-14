using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBuy7.Data;
using ShopBuy7.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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
            model.Products = context.Products.OrderByDescending(x => x.ProductId).Where(x => x.IsActive && !x.IsDeleted).Take(100).ToList();
            model.Banners = context.Banners.OrderByDescending(x => x.BannerId).Where(x => x.IsActive).ToList();
            model.Categories = context.Categories.OrderBy(x => x.Name).ToList();
            return View(model);
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
                                new Claim("userid", customer.CustomerId.ToString()),
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