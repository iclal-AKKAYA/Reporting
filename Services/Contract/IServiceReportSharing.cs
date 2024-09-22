using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceReportSharing
    {
        // Tüm ReportSharing kayıtlarını getirir
        Task<IEnumerable<ReportSharing>> GetAllReportSharingsAsync(bool trackChanges);

        // ID'ye göre tek bir ReportSharing getirir
        Task<ReportSharing> GetReportSharingByIdAsync(Guid id, bool trackChanges);

        // Sayfalama ile ReportSharing kayıtlarını getirir
        Task<IEnumerable<ReportSharing>> GetPagedReportSharingsAsync(RequestParameters parameters, bool trackChanges);

        // Yeni ReportSharing kaydı oluşturur
        Task<ReportSharing> CreateReportSharingAsync(ReportSharing reportSharing);

        // ReportSharing kaydını günceller
        void UpdateReportSharing(ReportSharing reportSharing);

        // ReportSharing kaydını siler
        void DeleteReportSharing(Guid id);
    }
}
