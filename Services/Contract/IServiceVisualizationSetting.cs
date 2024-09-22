using Entities.Models;
using Entities;

public interface IServiceVisualizationSetting
{
    Task<IEnumerable<VisualizationSetting>> GetAllVisualizationSettingsAsync(bool trackChanges);
    Task<VisualizationSetting> GetVisualizationSettingByIdAsync(Guid id, bool trackChanges);
    Task CreateVisualizationSettingAsync(VisualizationSetting visualizationSetting);
    void UpdateVisualizationSetting(VisualizationSetting visualizationSetting);
    Task DeleteVisualizationSettingAsync(Guid id); // Asenkron silme metodu eklendi
    Task<IEnumerable<VisualizationSetting>> GetPagedVisualizationSettingsAsync(RequestParameters parameters, bool trackChanges);
}
