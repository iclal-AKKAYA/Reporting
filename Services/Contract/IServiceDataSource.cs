using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceDataSource
    {
        // Tüm DataSource'ları getirir
        Task<IEnumerable<DataSource>> GetAllDataSourcesAsync(bool trackChanges);

        // ID'ye göre tek bir DataSource getirir
        Task<DataSource> GetDataSourceByIdAsync(Guid id, bool trackChanges);

        // Sayfalama ile DataSource'ları getirir
        Task<IEnumerable<DataSource>> GetPagedDataSourcesAsync(RequestParameters parameters, bool trackChanges);

        // Yeni bir DataSource oluşturur
        Task CreateDataSourceAsync(DataSource dataSource);

        // DataSource günceller
        void UpdateDataSource(DataSource dataSource);

        // DataSource siler
        Task DeleteDataSourceAsync(Guid id);
    }
}
