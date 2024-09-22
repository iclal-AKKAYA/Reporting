using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryVisualizationSetting : RepositoryBase<VisualizationSetting>, IRepositoryVisualizationSetting
    {
        public RepositoryVisualizationSetting(RepositoryContext context) : base(context)
        {
        }

        // Tüm VisualizationSetting kayıtlarını getirir
        public async Task<IEnumerable<VisualizationSetting>> GetAllVisualizationSettingsAsync(bool trackChanges)
        {
            return await GenericRead(trackChanges).ToListAsync();
        }

        // ID'ye göre tek bir VisualizationSetting getirir
        public async Task<VisualizationSetting> GetVisualizationSettingByIdAsync(Guid id, bool trackChanges)
        {
            return await GenericReadExpression(x => x.VisualizationID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        // Sayfalama ile VisualizationSetting kayıtlarını getirir
        public async Task<IEnumerable<VisualizationSetting>> GetPagedVisualizationSettingsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await GenericRead(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        // Yeni VisualizationSetting kaydı oluşturur
        public async Task CreateVisualizationSettingAsync(VisualizationSetting visualizationSetting)
        {
            await GenericCreateAsync(visualizationSetting);
        }

        // VisualizationSetting kaydını günceller
        public void UpdateVisualizationSetting(VisualizationSetting visualizationSetting)
        {
            GenericUpdate(visualizationSetting);
        }

        // VisualizationSetting kaydını siler
        public void DeleteVisualizationSetting(VisualizationSetting visualizationSetting)
        {
            GenericDelete(visualizationSetting);
        }
    }
}
