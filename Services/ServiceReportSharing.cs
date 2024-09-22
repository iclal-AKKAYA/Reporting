using Entities;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceReportSharing : IServiceReportSharing
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceReportSharing(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // Tüm ReportSharing kayıtlarını getirir
        public async Task<IEnumerable<ReportSharing>> GetAllReportSharingsAsync(bool trackChanges)
        {
            return await _repositoryManager.ReportSharing.GetAllReportSharingsAsync(trackChanges);
        }

        // ID'ye göre tek bir ReportSharing getirir
        public async Task<ReportSharing> GetReportSharingByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.ReportSharing.GetReportSharingByIdAsync(id, trackChanges);
        }

        // Sayfalama ile ReportSharing kayıtlarını getirir
        public async Task<IEnumerable<ReportSharing>> GetPagedReportSharingsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await _repositoryManager.ReportSharing.GetPagedReportSharingsAsync(parameters, trackChanges);
        }

        // Yeni ReportSharing kaydı oluşturur
        public async Task<ReportSharing> CreateReportSharingAsync(ReportSharing reportSharing)
        {
            await _repositoryManager.ReportSharing.CreateReportSharingAsync(reportSharing);
            _repositoryManager.Save();
            return reportSharing;
        }

        // ReportSharing kaydını günceller
        public void UpdateReportSharing(ReportSharing reportSharing)
        {
            _repositoryManager.ReportSharing.UpdateReportSharing(reportSharing);
            _repositoryManager.Save();
        }

        // ReportSharing kaydını siler
        public void DeleteReportSharing(Guid id)
        {
            var reportSharing = _repositoryManager.ReportSharing.GetReportSharingByIdAsync(id, false).Result;
            if (reportSharing != null)
            {
                _repositoryManager.ReportSharing.DeleteReportSharing(reportSharing);
                _repositoryManager.Save();
            }
        }
    }
}
