
using maxim.data.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace maxim.MVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
        {
			_context = context;
		}
       

        public  IActionResult Index()
        {
            var features= _context.Features.ToList();
            return View(features);
        }

        
    }
}