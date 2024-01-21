using maxim.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace maxim.MVC.Areas.manage.Controllers
{
	[Area("manage")]
	[Authorize(Roles ="SuperAdmin")]
	public class DashboardController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DashboardController(UserManager<AppUser>userManager,RoleManager<IdentityRole>roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		//public async Task<IActionResult> CreateRole()
		//{
		//	var role1 = new IdentityRole("SuperAdmin");
		//	var role2 = new IdentityRole("Admin");
		//	var role3 = new IdentityRole("user");
		//	await _roleManager.CreateAsync(role1);
		//	await _roleManager.CreateAsync(role2);
		//	await _roleManager.CreateAsync(role3);
		//	return Ok();
		//}
		//public async Task<IActionResult> CreateAdmin()
		//{
		//	var admin = new AppUser
		//	{
		//		FullName = "Reqsane Mustafayeva",
		//		UserName = "SuperAdmin"
		//	};
		//	await _userManager.CreateAsync(admin,"Admin123@");
		//	await _userManager.AddToRoleAsync(admin, "SuperAdmin");
		//	return Ok();
		//}
	}
}
