using Microsoft.AspNetCore.Mvc;

namespace maxim.MVC.Areas.manage.Controllers
{
	[Area("manage")]
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
