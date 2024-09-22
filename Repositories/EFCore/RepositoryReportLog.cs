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
    public class RepositoryReportLog : RepositoryBase<ReportLog>, IRepositoryReportLog
    {
        public RepositoryReportLog(RepositoryContext context) : base(context)
        {
        }

        // Tüm ReportLog kayıtlarını getirir
        public async Task<IEnumerable<ReportLog>> GetAllReportLogsAsync(bool trackChanges)
        {
            return await GenericRead(trackChanges).ToListAsync();
        }

        // ID'ye göre tek bir ReportLog getirir
        public async Task<ReportLog> GetReportLogByIdAsync(Guid id, bool trackChanges)
        {
            return await GenericReadExpression(x => x.LogID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        // Sayfalama ile ReportLog kayıtlarını getirir
        public async Task<IEnumerable<ReportLog>> GetPagedReportLogsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await GenericRead(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        // Yeni ReportLog kaydı oluşturur
        public async Task CreateReportLogAsync(ReportLog reportLog)
        {
            await GenericCreateAsync(reportLog);
        }

        // ReportLog kaydını günceller
        public void UpdateReportLog(ReportLog reportLog)
        {
            GenericUpdate(reportLog);
        }

        // ReportLog kaydını siler
        public void DeleteReportLog(ReportLog reportLog)
        {
            GenericDelete(reportLog);
        }
    }
}
