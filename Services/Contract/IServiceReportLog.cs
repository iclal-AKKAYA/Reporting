using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceReportLog
    {
        // Tüm ReportLog kayıtlarını getirir
        Task<IEnumerable<ReportLog>> GetAllReportLogsAsync(bool trackChanges);

        // ID'ye göre tek bir ReportLog getirir
        Task<ReportLog> GetReportLogByIdAsync(Guid id, bool trackChanges);

        // Sayfalama ile ReportLog kayıtlarını getirir
        Task<IEnumerable<ReportLog>> GetPagedReportLogsAsync(RequestParameters parameters, bool trackChanges);

        // Yeni ReportLog kaydı oluşturur
        Task<ReportLog> CreateReportLogAsync(ReportLog reportLog);

        // ReportLog kaydını günceller
        void UpdateReportLog(ReportLog reportLog);

        // ReportLog kaydını siler
        void DeleteReportLog(Guid id);
    }
}
