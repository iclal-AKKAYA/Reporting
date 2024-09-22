using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryConnectionSite : IRepositoryBase<ConnectionSite>
    {
        Task<IEnumerable<ConnectionSite>> GetAllConnectionSitesAsync(bool trackChanges);
        Task<IEnumerable<ConnectionSite>> GetPagedConnectionSitesAsync(RequestParameters parameters, bool trackChanges);
        Task<ConnectionSite> GetConnectionSiteByIdAsync(Guid id, bool trackChanges);
        Task CreateConnectionSiteAsync(ConnectionSite connectionSite);
        void UpdateConnectionSite(ConnectionSite connectionSite);
        void DeleteConnectionSite(ConnectionSite connectionSite);
    }
}
