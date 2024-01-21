using maxim.business.Exceptions;
using maxim.business.Services.Implementations;
using maxim.business.Services.Interfaces;
using maxim.core.Models;
using maxim.core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace maxim.MVC.Areas.manage.Controllers
{
	[Area("manage")]
	public class SettingController : Controller
	{
		private readonly ISettingService _settingService;

		public SettingController(ISettingService settingService)
		{
			_settingService = settingService;
		}
		public async Task<IActionResult> Index()
		{
			var settings = await _settingService.GetAllAsync();
			return View(settings);
		}
		public async Task<IActionResult> Update(int id)
		{
			var existsetting = await _settingService.GetByIdAsync(id);
			if (existsetting == null)
			{
				return View("error");

			}
			return View(existsetting);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(Setting setting)
		{
			if (!ModelState.IsValid)
			{
				return View(setting);
			}
			try
			{
				await _settingService.UpdateAsync(setting);
			}
			catch (SettingNotFoundException)
			{
				return View("error");
			}

			return RedirectToAction("Index");
		}
	}
}
