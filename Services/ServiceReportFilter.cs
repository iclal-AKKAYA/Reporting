using Entities;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceReportFilter : IServiceReportFilter
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceReportFilter(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ReportFilter>> GetAllReportFiltersAsync(bool trackChanges)
        {
            return await _repositoryManager.ReportFilter.GetAllReportFiltersAsync(trackChanges);
        }

        public async Task<ReportFilter> GetReportFilterByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.ReportFilter.GetReportFilterByIdAsync(id, trackChanges);
        }

        public async Task CreateReportFilterAsync(ReportFilter reportFilter)
        {
            await _repositoryManager.ReportFilter.CreateReportFilterAsync(reportFilter);
            await _repositoryManager.SaveAsync();
        }

        public void UpdateReportFilter(ReportFilter reportFilter)
        {
            _repositoryManager.ReportFilter.UpdateReportFilter(reportFilter);
            _repositoryManager.Save();
        }

        public async Task DeleteReportFilterAsync(Guid id)
        {
            var reportFilter = await _repositoryManager.ReportFilter.GetReportFilterByIdAsync(id, false);
            if (reportFilter != null)
            {
                _repositoryManager.ReportFilter.DeleteReportFilter(reportFilter);
                await _repositoryManager.SaveAsync();
            }
        }

        public async Task<IEnumerable<ReportFilter>> GetPagedReportFiltersAsync(RequestParameters parameters, bool trackChanges)
        {
            return await _repositoryManager.ReportFilter.GetPagedReportFiltersAsync(parameters, trackChanges); // Bu metodu kullanıyoruz
        }
    }
}
