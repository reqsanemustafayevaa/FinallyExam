using maxim.business.Exceptions;
using maxim.business.Extentions;
using maxim.business.Services.Interfaces;
using maxim.core.Models;
using maxim.core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IWebHostEnvironment _env;

        public FeatureService(IFeatureRepository featureRepository
                              ,IWebHostEnvironment env)
        {
            _featureRepository = featureRepository;
            _env = env;
        }
        public async Task CreateAsync(Feature feature)
        {
            if(feature == null)
            {
                throw new FeatureNotFoundException();
            }
            if(feature.ImageFile is not null)
            {
                if(feature.ImageFile.ContentType!="image/png"&& feature.ImageFile.ContentType!="image/jpeg")
                {
                    throw new ImageContentException("ImageFile","File must be .jpeg or .png!");
                }
                if (feature.ImageFile.Length > 1072346)
                {
                    throw new InvalidImageSizeException("ImageFile","File must be lower than 1mb!");
                }
                feature.ImageUrl = feature.ImageFile.SaveFile(_env.WebRootPath, "uploads/features");
            }
            feature.IsDeleted= false;
            feature.CrteateDate= DateTime.UtcNow;
            feature.UpdateDate = DateTime.UtcNow;
            await _featureRepository.CreateAsync(feature);
            await _featureRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var existfeature =await _featureRepository.GetByidAsync(x => x.Id == id);
            if (existfeature is null)
            {
                throw new FeatureNotFoundException();
            }
            Helper.DeleteFile(_env.WebRootPath, "uploads/features", existfeature.ImageUrl);
            _featureRepository.Delete(existfeature);
            await _featureRepository.CommitAsync();
        }

        public async Task<List<Feature>> GetAllAsync()
        {
            return await _featureRepository.GetAllAsync().ToListAsync();
        }

        public  async Task<Feature> GetByIdAsync(int id)
        {
            var feature=await _featureRepository.GetByidAsync(x=>x.Id==id);
            if(feature is null)
            {
                throw new FeatureNotFoundException();
            }
            
            return feature;
        }

        public async Task UpdateAsync(Feature feature)
        {
            
            var existfeature =await _featureRepository.GetByidAsync(x => x.Id == feature.Id);
            if (feature is null)
            {
                throw new FeatureNotFoundException();
            }
            if (feature.ImageFile is not null)
            {
                if (feature.ImageFile.ContentType != "image/png" && feature.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "File must be .jpeg or .png!");
                }
                if (feature.ImageFile.Length > 1072346)
                {
                    throw new InvalidImageSizeException("ImageFile", "File must be lower than 1mb!");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/features",existfeature.ImageUrl);
                existfeature.ImageUrl = feature.ImageFile.SaveFile(_env.WebRootPath, "uploads/features");
            }
            existfeature.Name = feature.Name;
            existfeature.Description = feature.Description;
            existfeature.IsDeleted = false;
            existfeature.UpdateDate= DateTime.UtcNow;
            await _featureRepository.CommitAsync();
        }
    }
}
