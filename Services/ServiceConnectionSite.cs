using Entities;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceConnectionSite : IServiceConnectionSite
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceConnectionSite(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // Tüm connection site'leri getirir.
        public async Task<IEnumerable<ConnectionSite>> GetAllConnectionSitesAsync(bool trackChanges)
        {
            return await _repositoryManager.ConnectionSite.GetAllConnectionSitesAsync(trackChanges);
        }

        // ID'ye göre tek bir connection site getirir.
        public async Task<ConnectionSite> GetConnectionSiteByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.ConnectionSite.GetConnectionSiteByIdAsync(id, trackChanges);
        }

        // Sayfalama ile connection site'leri getirir.
        public async Task<IEnumerable<ConnectionSite>> GetPagedConnectionSitesAsync(RequestParameters parameters, bool trackChanges)
        {
            return await _repositoryManager.ConnectionSite.GetPagedConnectionSitesAsync(parameters, trackChanges);
        }

        // Yeni bir connection site oluşturur.
        public async Task CreateConnectionSiteAsync(ConnectionSite connectionSite)
        {
            await _repositoryManager.ConnectionSite.CreateConnectionSiteAsync(connectionSite);
            _repositoryManager.Save();
        }

        // Connection site'yi günceller.
        public void UpdateConnectionSite(ConnectionSite connectionSite)
        {
            _repositoryManager.ConnectionSite.UpdateConnectionSite(connectionSite);
            _repositoryManager.Save();
        }

        // Connection site'yi siler.
        public void DeleteConnectionSite(ConnectionSite connectionSite)
        {
            _repositoryManager.ConnectionSite.DeleteConnectionSite(connectionSite);
            _repositoryManager.Save();
        }
    }
}
