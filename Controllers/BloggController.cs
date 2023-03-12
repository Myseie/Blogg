using Blogg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Blogg.Controllers
{
    public class BloggController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async IActionResult Create (string title, string summary, string content)
        {
            var db = new Database();
            db.SaveBlogg(string title, string summary, string content);
            

        }

        [HttpPost]
        public async IActionResult Create(Blogg blogg)
    }
}
