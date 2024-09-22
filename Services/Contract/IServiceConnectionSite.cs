using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceConnectionSite
    {
        Task<IEnumerable<ConnectionSite>> GetAllConnectionSitesAsync(bool trackChanges);
        Task<IEnumerable<ConnectionSite>> GetPagedConnectionSitesAsync(RequestParameters parameters, bool trackChanges);
        Task<ConnectionSite> GetConnectionSiteByIdAsync(Guid id, bool trackChanges);
        Task CreateConnectionSiteAsync(ConnectionSite connectionSite);
        void UpdateConnectionSite(ConnectionSite connectionSite);
        void DeleteConnectionSite(ConnectionSite connectionSite);
    }
}
