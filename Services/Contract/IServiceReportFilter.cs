using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceReportFilter
    {
        Task<IEnumerable<ReportFilter>> GetAllReportFiltersAsync(bool trackChanges);
        Task<ReportFilter> GetReportFilterByIdAsync(Guid id, bool trackChanges);
        Task CreateReportFilterAsync(ReportFilter reportFilter);
        void UpdateReportFilter(ReportFilter reportFilter);
        Task DeleteReportFilterAsync(Guid id);
        Task<IEnumerable<ReportFilter>> GetPagedReportFiltersAsync(RequestParameters parameters, bool trackChanges); // Bu metodu ekledik
    }
}
