using maxim.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.Services.Interfaces
{
	public interface ISettingService
	{
		Task UpdateAsync(Setting setting);
		Task<List<Setting>> GetAllAsync();
		Task<Setting> GetByIdAsync(int id);
	}
}
