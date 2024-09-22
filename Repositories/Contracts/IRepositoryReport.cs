using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryReport : IRepositoryBase<Report>
    {
        Task<IEnumerable<Report>> GetAllReportsAsync(bool trackChanges);
        Task<Report> GetReportAsync(Guid id, bool trackChanges);
        Task<IEnumerable<Report>> GetPagedReportsAsync(RequestParameters parameters, bool trackChanges); // Eksik metod burada ekleniyor
        Task CreateReportAsync(Report report);
        void UpdateReport(Report report);
        void DeleteReport(Report report);
    }
}
