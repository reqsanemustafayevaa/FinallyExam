using maxim.business.Exceptions;
using maxim.business.Extentions;
using maxim.business.Services.Interfaces;
using maxim.core.Models;
using maxim.core.Repositories.Interfaces;
using maxim.data.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.Services.Implementations
{
	public class SettingService : ISettingService
	{
		private readonly ISettingRepository _settingRepository;

		public SettingService(ISettingRepository settingRepository)
		{
			_settingRepository = settingRepository;
		}
		public async Task<List<Setting>> GetAllAsync()
		{
			return await _settingRepository.GetAllAsync().ToListAsync();
		}

		public async Task<Setting> GetByIdAsync(int id)
		{
			var setting = await _settingRepository.GetByidAsync(x => x.Id == id);
			if (setting is null)
			{
				throw new FeatureNotFoundException();
			}

			return setting;
		}

		public async Task UpdateAsync(Setting setting)
		{
			var existsetting = await _settingRepository.GetByidAsync(x => x.Id == setting.Id);
			if (existsetting is null)
			{
				throw new SettingNotFoundException();

			}

			existsetting.Value= setting.Value;
			
			existsetting.IsDeleted = false;
			existsetting.UpdateDate = DateTime.UtcNow;
			await _settingRepository.CommitAsync();
		}
	}
}
