using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryReportFilter : IRepositoryBase<ReportFilter>
    {
        Task<IEnumerable<ReportFilter>> GetAllReportFiltersAsync(bool trackChanges);
        Task<ReportFilter> GetReportFilterByIdAsync(Guid id, bool trackChanges);
        Task CreateReportFilterAsync(ReportFilter reportFilter);
        void UpdateReportFilter(ReportFilter reportFilter);
        void DeleteReportFilter(ReportFilter reportFilter);
        Task<IEnumerable<ReportFilter>> GetPagedReportFiltersAsync(RequestParameters parameters, bool trackChanges); // Bu metodu ekleyin
    }
}
