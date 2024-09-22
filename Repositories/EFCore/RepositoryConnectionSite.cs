using Entities.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

public class RepositoryConnectionSite : RepositoryBase<ConnectionSite>, IRepositoryConnectionSite
{
    private readonly RepositoryContext _context;

    public RepositoryConnectionSite(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    // Tüm connection site'leri getirir.
    public async Task<IEnumerable<ConnectionSite>> GetAllConnectionSitesAsync(bool trackChanges)
    {
        return await GenericRead(trackChanges).ToListAsync(); // ToListAsync ile IEnumerable listesine çevir
    }

    // ID'ye göre tek bir connection site getirir.
    public async Task<ConnectionSite> GetConnectionSiteByIdAsync(Guid id, bool trackChanges)
    {
        return await GenericReadExpression(x => x.SiteID.Equals(id), trackChanges)
            .SingleOrDefaultAsync(); // SingleOrDefaultAsync ile tek bir sonucu getir
    }

    // Sayfalama ile connection site'leri getirir.
    public async Task<IEnumerable<ConnectionSite>> GetPagedConnectionSitesAsync(RequestParameters parameters, bool trackChanges)
    {
        return await GenericRead(trackChanges)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(); // Sayfalama işlemi için ToListAsync kullan
    }

    // Yeni bir connection site oluşturur.
    public async Task CreateConnectionSiteAsync(ConnectionSite connectionSite)
    {
        await GenericCreateAsync(connectionSite);
    }

    // Connection site'yi günceller.
    public void UpdateConnectionSite(ConnectionSite connectionSite)
    {
        GenericUpdate(connectionSite);
    }

    // Connection site'yi siler.
    public void DeleteConnectionSite(ConnectionSite connectionSite)
    {
        GenericDelete(connectionSite);
    }
}
