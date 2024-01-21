using maxim.business.Exceptions;
using maxim.business.Services.Interfaces;
using maxim.business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace maxim.MVC.Areas.manage.Controllers
{
	[Area("manage")]
	
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		public IActionResult Login()
		{

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginVm)
		{
			if(!ModelState.IsValid)
			{
				return View(loginVm);
			}
			try
			{
				await _authService.Login(loginVm);
			}
			catch (InvalidCredsException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View(loginVm);
			}
			return RedirectToAction("index", "feature");
		}
	}
}
