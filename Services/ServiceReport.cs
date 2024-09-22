using Entities;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceReport : IServiceReport
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceReport(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // Tüm raporları getirir
        public async Task<IEnumerable<Report>> GetAllReportsAsync(bool trackChanges)
        {
            return await _repositoryManager.Report.GetAllReportsAsync(trackChanges);
        }

        // ID'ye göre tek bir rapor getirir
        public async Task<Report> GetReportByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.Report.GetReportAsync(id, trackChanges);
        }

        // Yeni bir rapor oluşturur
        public async Task CreateReportAsync(Report report)
        {
            await _repositoryManager.Report.CreateReportAsync(report);
            await _repositoryManager.SaveAsync();
        }

        // Raporu günceller
        public void UpdateReport(Report report)
        {
            _repositoryManager.Report.UpdateReport(report);
            _repositoryManager.Save();
        }

        // Raporu siler
        public async Task DeleteReportAsync(Guid id)
        {
            var report = await _repositoryManager.Report.GetReportAsync(id, false);
            if (report == null)
            {
                throw new Exception("Rapor bulunamadı");
            }
            _repositoryManager.Report.DeleteReport(report);
            await _repositoryManager.SaveAsync();
        }

        // Sayfalama ile raporları getirir
        public async Task<IEnumerable<Report>> GetPagedReportsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await _repositoryManager.Report.GetPagedReportsAsync(parameters, trackChanges);
        }

        // Şekillendirilmiş (Shape Data) raporları getirir
        public async Task<IEnumerable<Report>> GetPagedAndShapedReportsAsync(RequestParameters parameters, bool trackChanges)
        {
            // Veriyi şekillendirme işlemi burada yapılabilir.
            var reports = await _repositoryManager.Report.GetPagedReportsAsync(parameters, trackChanges);
            // Örnek bir şekillendirme adımı eklenebilir
            return reports; // Datanın şekillendirilmiş hali
        }
    }
}
