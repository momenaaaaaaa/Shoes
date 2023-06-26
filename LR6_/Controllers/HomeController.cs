using LR6_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR6_.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        private readonly ILogger<HomeController> _logger;


        public HomeController(MobileContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.Shoes.ToList());
        }
        public IActionResult ListT()
        {
            return View(db.Shoes.ToList());
        }
        public IActionResult LK(User model)
        {
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Phone, string Parol, bool Remember)
        {

            User user = db.Users.FirstOrDefault(u => u.NumberTelephone == Phone && u.Password == Parol);
            if (user != null)
            {
                HttpContext.Session.SetString("session", user.UserId.ToString());
                var luser = new User
                {
                    UserId = user.UserId,
                    NumberTelephone = Phone,
                    Password = Parol,
                    Name = user.Name,
                };
                return RedirectToAction("LK", "Home", luser);
            }
            else
            {
                ViewBag.Message1 = "Неверный логин/пароль!";
                return View();
            }
        }
        [HttpPost]
        public IActionResult Registr(string name, bool one, string phone, string password)
        {

            User proverka = db.Users.FirstOrDefault(u => u.NumberTelephone == phone && u.Password == password);
            if (proverka != null)
            {
                ViewBag.Message = "Ошибка! Проверьте введенные данные";
                return View();
            }
            else
            {
                var newUser = new User
                {
                    Name = name,
                    NumberTelephone = phone,
                    Password = password
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

        }
    }
}