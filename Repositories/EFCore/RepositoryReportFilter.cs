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
    public class RepositoryReportFilter : RepositoryBase<ReportFilter>, IRepositoryReportFilter
    {
        public RepositoryReportFilter(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ReportFilter>> GetAllReportFiltersAsync(bool trackChanges)
        {
            return await GenericRead(trackChanges).ToListAsync();
        }

        public async Task<ReportFilter> GetReportFilterByIdAsync(Guid id, bool trackChanges)
        {
            return await GenericReadExpression(x => x.FilterID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task CreateReportFilterAsync(ReportFilter reportFilter)
        {
            await GenericCreateAsync(reportFilter);
        }

        public void UpdateReportFilter(ReportFilter reportFilter)
        {
            GenericUpdate(reportFilter);
        }

        public void DeleteReportFilter(ReportFilter reportFilter)
        {
            GenericDelete(reportFilter);
        }

        // Sayfalama ile ReportFilter'ları getirir
        public async Task<IEnumerable<ReportFilter>> GetPagedReportFiltersAsync(RequestParameters parameters, bool trackChanges)
        {
            return await GenericRead(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }
    }
}
