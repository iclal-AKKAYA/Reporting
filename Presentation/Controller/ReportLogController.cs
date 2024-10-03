using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportLogController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReportLogController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Tüm ReportLog kayıtlarını getirir
        [HttpGet("get-all-report-logs")]
        public async Task<IActionResult> GetAllReportLogs()
        {
            var reportLogs = await _serviceManager.ServiceReportLog.GetAllReportLogsAsync(false);
            if (reportLogs != null)
            {
                return Ok(new
                {
                    @Localizer = "Report logs fetched successfully",
                    reportLogs
                });
            }
            return NotFound(new
            {
                @Localizer = "No report logs found"
            });
        }

        // ID'ye göre tek bir ReportLog getirir
        [HttpGet("get-report-log-by-id/{id}")]
        public async Task<IActionResult> GetReportLog(Guid id)
        {
            var reportLog = await _serviceManager.ServiceReportLog.GetReportLogByIdAsync(id, false);
            if (reportLog != null)
            {
                return Ok(new
                {
                    @Localizer = "Report log fetched successfully",
                    reportLog
                });
            }
            return NotFound(new
            {
                @Localizer = "Report log not found"
            });
        }

        // Yeni bir ReportLog ekler
        [HttpPost("add-report-log")]
        public async Task<IActionResult> AddReportLog([FromBody] ReportLog reportLog)
        {
            await _serviceManager.ServiceReportLog.CreateReportLogAsync(reportLog);
            return Ok(new
            {
                @Localizer = "Report log added successfully",
                reportLog
            });
        }

        // ReportLog günceller
        [HttpPut("update-report-log")]
        public IActionResult UpdateReportLog([FromBody] ReportLog reportLog)
        {
            var existingReportLog = _serviceManager.ServiceReportLog.GetReportLogByIdAsync(reportLog.LogID, false).Result;
            if (existingReportLog != null)
            {
                _serviceManager.ServiceReportLog.UpdateReportLog(reportLog);
                return Ok(new
                {
                    @Localizer = "Report log updated successfully",
                    reportLog
                });
            }
            return NotFound(new
            {
                @Localizer = "Report log not found for update"
            });
        }

        // ReportLog siler
        [HttpDelete("delete-report-log/{id}")]
        public async Task<IActionResult> DeleteReportLog(Guid id)
        {
            var reportLog = await _serviceManager.ServiceReportLog.GetReportLogByIdAsync(id, false);
            if (reportLog != null)
            {
                _serviceManager.ServiceReportLog.DeleteReportLog(id);
                return Ok(new
                {
                    @Localizer = "Report log deleted successfully",
                    reportLog
                });
            }
            return NotFound(new
            {
                @Localizer = "Report log not found for deletion"
            });
        }
    }
}
