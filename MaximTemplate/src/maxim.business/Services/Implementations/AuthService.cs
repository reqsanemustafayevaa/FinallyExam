using maxim.business.Exceptions;
using maxim.business.Services.Interfaces;
using maxim.business.ViewModels;
using maxim.core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.Services.Implementations
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AuthService(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public  async Task Login(LoginViewModel loginVm)
		{
			AppUser admin = null;
			admin = await _userManager.FindByNameAsync(loginVm.Username);
			if (admin == null)
			{
				throw new InvalidCredsException("","Invalid UserName or Password!");
			}
			var result=await _signInManager.PasswordSignInAsync(admin, loginVm.Password,false,false);
			if (!result.Succeeded)
			{
				throw new InvalidCredsException("", "Invalid UserName or Password!");
			}



			
		}
	}
}
