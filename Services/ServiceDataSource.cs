using Entities;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceDataSource : IServiceDataSource
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceDataSource(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // Tüm DataSource'ları getirir.
        public async Task<IEnumerable<DataSource>> GetAllDataSourcesAsync(bool trackChanges)
        {
            return await _repositoryManager.DataSource.GetAllDataSourcesAsync(trackChanges);
        }

        // ID'ye göre tek bir DataSource getirir.
        public async Task<DataSource> GetDataSourceByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.DataSource.GetDataSourceByIdAsync(id, trackChanges);
        }

        // Sayfalama ile DataSource'ları getirir.
        public async Task<IEnumerable<DataSource>> GetPagedDataSourcesAsync(RequestParameters parameters, bool trackChanges)
        {
            return await _repositoryManager.DataSource.GetPagedDataSourcesAsync(parameters, trackChanges);
        }

        // Yeni bir DataSource oluşturur.
        public async Task CreateDataSourceAsync(DataSource dataSource)
        {
            await _repositoryManager.DataSource.CreateDataSourceAsync(dataSource);
            await _repositoryManager.SaveAsync();
        }

        // DataSource günceller.
        public void UpdateDataSource(DataSource dataSource)
        {
            _repositoryManager.DataSource.UpdateDataSource(dataSource);
            _repositoryManager.Save();
        }

        // DataSource siler.
        public async Task DeleteDataSourceAsync(Guid id)
        {
            var dataSource = await _repositoryManager.DataSource.GetDataSourceByIdAsync(id, true);
            if (dataSource == null)
                throw new Exception($"DataSource with id: {id} not found");

            _repositoryManager.DataSource.DeleteDataSource(dataSource);
            await _repositoryManager.SaveAsync();
        }
    }
}
