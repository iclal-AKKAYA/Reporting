using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryDataSource : IRepositoryBase<DataSource>
    {
        Task<IEnumerable<DataSource>> GetAllDataSourcesAsync(bool trackChanges);
        Task<DataSource> GetDataSourceByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<DataSource>> GetPagedDataSourcesAsync(RequestParameters parameters, bool trackChanges);
        Task CreateDataSourceAsync(DataSource dataSource);
        void UpdateDataSource(DataSource dataSource);
        void DeleteDataSource(DataSource dataSource);
    }
}
