using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ProductDbContext db;
        //public HomeController(ProductDbContext db)
        //{
        //    this.db = db;
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
