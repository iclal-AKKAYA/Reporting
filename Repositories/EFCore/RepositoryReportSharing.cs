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
    public class RepositoryReportSharing : RepositoryBase<ReportSharing>, IRepositoryReportSharing
    {
        public RepositoryReportSharing(RepositoryContext context) : base(context)
        {
        }

        // Tüm ReportSharing kayıtlarını getirir
        public async Task<IEnumerable<ReportSharing>> GetAllReportSharingsAsync(bool trackChanges)
        {
            return await GenericRead(trackChanges).ToListAsync();
        }

        // ID'ye göre tek bir ReportSharing getirir
        public async Task<ReportSharing> GetReportSharingByIdAsync(Guid id, bool trackChanges)
        {
            return await GenericReadExpression(x => x.ShareID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }

        // Sayfalama ile ReportSharing kayıtlarını getirir
        public async Task<IEnumerable<ReportSharing>> GetPagedReportSharingsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await GenericRead(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        // Yeni ReportSharing kaydı oluşturur
        public async Task CreateReportSharingAsync(ReportSharing reportSharing)
        {
            await GenericCreateAsync(reportSharing);
        }

        // ReportSharing kaydını günceller
        public void UpdateReportSharing(ReportSharing reportSharing)
        {
            GenericUpdate(reportSharing);
        }

        // ReportSharing kaydını siler
        public void DeleteReportSharing(ReportSharing reportSharing)
        {
            GenericDelete(reportSharing);
        }
    }
}
