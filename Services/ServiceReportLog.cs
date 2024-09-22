using Entities;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceReportLog : IServiceReportLog
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceReportLog(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // Tüm ReportLog kayıtlarını getirir
        public async Task<IEnumerable<ReportLog>> GetAllReportLogsAsync(bool trackChanges)
        {
            return await _repositoryManager.ReportLog.GetAllReportLogsAsync(trackChanges);
        }

        // ID'ye göre tek bir ReportLog getirir
        public async Task<ReportLog> GetReportLogByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.ReportLog.GetReportLogByIdAsync(id, trackChanges);
        }

        // Sayfalama ile ReportLog kayıtlarını getirir
        public async Task<IEnumerable<ReportLog>> GetPagedReportLogsAsync(RequestParameters parameters, bool trackChanges)
        {
            return await _repositoryManager.ReportLog.GetPagedReportLogsAsync(parameters, trackChanges);
        }

        // Yeni ReportLog kaydı oluşturur
        public async Task<ReportLog> CreateReportLogAsync(ReportLog reportLog)
        {
            await _repositoryManager.ReportLog.CreateReportLogAsync(reportLog);
            _repositoryManager.Save();
            return reportLog;
        }

        // ReportLog kaydını günceller
        public void UpdateReportLog(ReportLog reportLog)
        {
            _repositoryManager.ReportLog.UpdateReportLog(reportLog);
            _repositoryManager.Save();
        }

        // ReportLog kaydını siler
        public void DeleteReportLog(Guid id)
        {
            var reportLog = _repositoryManager.ReportLog.GetReportLogByIdAsync(id, false).Result;
            if (reportLog != null)
            {
                _repositoryManager.ReportLog.DeleteReportLog(reportLog);
                _repositoryManager.Save();
            }
        }
    }
}
