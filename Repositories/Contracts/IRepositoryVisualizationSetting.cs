using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryVisualizationSetting : IRepositoryBase<VisualizationSetting>
    {
        // Tüm VisualizationSetting kayıtlarını getirir
        Task<IEnumerable<VisualizationSetting>> GetAllVisualizationSettingsAsync(bool trackChanges);

        // ID'ye göre tek bir VisualizationSetting getirir
        Task<VisualizationSetting> GetVisualizationSettingByIdAsync(Guid id, bool trackChanges);

        // Sayfalama ile VisualizationSetting kayıtlarını getirir
        Task<IEnumerable<VisualizationSetting>> GetPagedVisualizationSettingsAsync(RequestParameters parameters, bool trackChanges);

        // Yeni VisualizationSetting kaydı oluşturur
        Task CreateVisualizationSettingAsync(VisualizationSetting visualizationSetting);

        // VisualizationSetting kaydını günceller
        void UpdateVisualizationSetting(VisualizationSetting visualizationSetting);

        // VisualizationSetting kaydını siler
        void DeleteVisualizationSetting(VisualizationSetting visualizationSetting);
    }
}
