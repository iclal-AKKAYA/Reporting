using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceReport
    {
        // Tüm raporları getirir
        Task<IEnumerable<Report>> GetAllReportsAsync(bool trackChanges);

        // ID'ye göre tek bir raporu getirir
        Task<Report> GetReportByIdAsync(Guid id, bool trackChanges);

        // Yeni bir rapor oluşturur
        Task CreateReportAsync(Report report);

        // Raporu günceller
        void UpdateReport(Report report);

        // Raporu siler
        Task DeleteReportAsync(Guid id);

        // Sayfalama ile raporları getirir
        Task<IEnumerable<Report>> GetPagedReportsAsync(RequestParameters parameters, bool trackChanges);

        // Şekillendirilmiş raporları getirir (Shape Data)
        Task<IEnumerable<Report>> GetPagedAndShapedReportsAsync(RequestParameters parameters, bool trackChanges);
    }
}
