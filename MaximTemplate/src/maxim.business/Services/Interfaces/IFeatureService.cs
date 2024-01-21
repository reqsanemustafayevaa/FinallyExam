using maxim.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.Services.Interfaces
{
    public interface IFeatureService
    {
        Task CreateAsync(Feature feature);
        Task UpdateAsync(Feature feature);
        Task Delete(Feature feature);
        Task<List<Feature>> GetAllAsync();
        Task<Feature> GetByIdAsync(int id);
       

    }
}
