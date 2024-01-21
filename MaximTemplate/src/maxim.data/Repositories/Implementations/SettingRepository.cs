using maxim.core.Models;
using maxim.core.Repositories.Interfaces;
using maxim.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.data.Repositories.Implementations
{
	public class SettingRepository : GenericRepository<Setting>, ISettingRepository
	{
		public SettingRepository(AppDbContext context) : base(context)
		{
		}
	}
}
