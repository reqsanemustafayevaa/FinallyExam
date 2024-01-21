using maxim.business.Services.Interfaces;
using maxim.core.Models;

namespace maxim.MVC.ViewServices
{
    
    public class LayoutService
    {
        private readonly ISettingService _settingService;

        public LayoutService(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<List<Setting>> GetSettings()
        {
            var settings=await _settingService.GetAllAsync();
            return settings;
        }
    }
}
