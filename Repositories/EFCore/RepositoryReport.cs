using Entities.Models;
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Repositories.EFCore
{
    public class RepositoryReport : RepositoryBase<Report>, IRepositoryReport
    {
        public RepositoryReport(RepositoryContext context) : base(context)
        {
        }

        // Tüm raporları getirir
        public async Task<IEnumerable<Report>> GetAllReportsAsync(bool trackChanges)
        {
            return await GenericRead(trackChanges).ToListAsync();
        }

        // ID'ye göre tek bir raporu getirir
        public async Task<Report> GetReportAsync(Guid id, bool trackChanges)
        {
            return await GenericReadExpression(x => x.ReportID.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        // Sayfalama ile raporları getirir (Eksik olan metod)
        public async Task<IEnumerable<Report>> GetPagedReportsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await GenericRead(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        // Yeni bir rapor oluşturur
        public async Task CreateReportAsync(Report report)
        {
            await GenericCreateAsync(report);
        }

        // Raporu günceller
        public void UpdateReport(Report report)
        {
            GenericUpdate(report);
        }

        // Raporu siler
        public void DeleteReport(Report report)
        {
            GenericDelete(report);
        }
    }
}
