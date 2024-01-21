using maxim.business.Exceptions;
using maxim.business.Services.Interfaces;
using maxim.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace maxim.MVC.Areas.manage.Controllers
{
	[Area("manage")]
	[Authorize(Roles = "SuperAdmin")]
	public class FeatureController : Controller
	{
		private readonly IFeatureService _featureService;

		public FeatureController(IFeatureService featureService)
		{
			_featureService = featureService;
		}
		public async Task<IActionResult> Index()
		{
			var features=await _featureService.GetAllAsync();
			return View(features);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Feature feature)
		{
			if(!ModelState.IsValid)
			{
				return View(feature);
			}
			try
			{
				await _featureService.CreateAsync(feature);
			}
			catch(FeatureNotFoundException )
			{
				return View("error");
			}
			catch(ImageContentException ex)
			{
				ModelState.AddModelError(ex.PropertyName, ex.Message);
				return View();
			}
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
			return RedirectToAction("Index");

        }
		public async Task<IActionResult> Update(int id)
		{
			var existfeature=await _featureService.GetByIdAsync(id);
			if(existfeature==null)
			{
				return View("error");

			}
			return View(existfeature);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async  Task<IActionResult> Update(Feature feature)
		{
			if(!ModelState.IsValid)
			{
				return View(feature);
			}
            try
            {
                await _featureService.UpdateAsync(feature);
            }
            catch (FeatureNotFoundException)
            {
                return View("error");
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            return RedirectToAction("Index");





        }
		public async  Task<IActionResult> Delete(int id)
		{
            var existfeature = await _featureService.GetByIdAsync(id);
            if (existfeature == null)
            {
                return View("error");

            }
            return View(existfeature);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async  Task<IActionResult> Delete(Feature feature)
		{
			try
			{
				await _featureService.Delete(feature.Id);
			}
			catch (FeatureNotFoundException )
			{
				return View("error");
			}
			
			return RedirectToAction("index");
		}
    }
}
