using Entities.Models;
using Entities;
using Repositories.Contracts;

public class ServiceVisualizationSetting : IServiceVisualizationSetting
{
    private readonly IRepositoryManager _repositoryManager;

    public ServiceVisualizationSetting(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<VisualizationSetting>> GetAllVisualizationSettingsAsync(bool trackChanges)
    {
        return await _repositoryManager.VisualizationSetting.GetAllVisualizationSettingsAsync(trackChanges);
    }

    public async Task<VisualizationSetting> GetVisualizationSettingByIdAsync(Guid id, bool trackChanges)
    {
        return await _repositoryManager.VisualizationSetting.GetVisualizationSettingByIdAsync(id, trackChanges);
    }

    public async Task CreateVisualizationSettingAsync(VisualizationSetting visualizationSetting)
    {
        await _repositoryManager.VisualizationSetting.CreateVisualizationSettingAsync(visualizationSetting);
        await _repositoryManager.SaveAsync();
    }

    public void UpdateVisualizationSetting(VisualizationSetting visualizationSetting)
    {
        _repositoryManager.VisualizationSetting.UpdateVisualizationSetting(visualizationSetting);
        _repositoryManager.SaveAsync();
    }

    public async Task DeleteVisualizationSettingAsync(Guid id)
    {
        var visualizationSetting = await _repositoryManager.VisualizationSetting.GetVisualizationSettingByIdAsync(id, false);
        if (visualizationSetting == null)
            throw new Exception("VisualizationSetting not found");

        _repositoryManager.VisualizationSetting.DeleteVisualizationSetting(visualizationSetting);
        await _repositoryManager.SaveAsync();
    }

    public async Task<IEnumerable<VisualizationSetting>> GetPagedVisualizationSettingsAsync(RequestParameters parameters, bool trackChanges)
    {
        return await _repositoryManager.VisualizationSetting.GetPagedVisualizationSettingsAsync(parameters, trackChanges);
    }
}
