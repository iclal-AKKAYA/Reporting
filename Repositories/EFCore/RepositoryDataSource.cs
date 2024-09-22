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
    public class RepositoryDataSource : RepositoryBase<DataSource>, IRepositoryDataSource
    {
        public RepositoryDataSource(RepositoryContext context) : base(context)
        {
        }

        // Tüm DataSource kayıtlarını getirir
        public async Task<IEnumerable<DataSource>> GetAllDataSourcesAsync(bool trackChanges)
        {
            return await GenericRead(trackChanges).ToListAsync();
        }

        // ID'ye göre tek bir DataSource getirir
        public async Task<DataSource> GetDataSourceByIdAsync(Guid id, bool trackChanges)
        {
            return await GenericReadExpression(x => x.SourceID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        // Sayfalama ile DataSource kayıtlarını getirir
        public async Task<IEnumerable<DataSource>> GetPagedDataSourcesAsync(RequestParameters parameters, bool trackChanges)
        {
            return await GenericRead(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        // Yeni DataSource kaydı oluşturur
        public async Task CreateDataSourceAsync(DataSource dataSource)
        {
            await GenericCreateAsync(dataSource);
        }

        // DataSource kaydını günceller
        public void UpdateDataSource(DataSource dataSource)
        {
            GenericUpdate(dataSource);
        }

        // DataSource kaydını siler
        public void DeleteDataSource(DataSource dataSource)
        {
            GenericDelete(dataSource);
        }
    }
}
