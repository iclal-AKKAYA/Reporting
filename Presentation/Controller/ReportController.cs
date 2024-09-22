using Entities;
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
    public class ReportController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReportController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Yeni bir Report ekler
        [HttpPost("add-report")]
        public async Task<IActionResult> AddReport([FromBody] Report report)
        {
            await _serviceManager.ServiceReport.CreateReportAsync(report);
            return Ok(new
            {
                @Localizer = "Report added successfully", // Localizer etiketi eklendi
                report
            });
        }

        // ID'ye göre bir Report getirir
        [HttpGet("get-report-by-id/{id}")]
        public async Task<IActionResult> GetReport(Guid id)
        {
            var report = await _serviceManager.ServiceReport.GetReportByIdAsync(id, false);
            if (report != null)
            {
                return Ok(new
                {
                    @Localizer = "Report fetched successfully", // Localizer etiketi eklendi
                    report
                });
            }
            return NotFound(new
            {
                @Localizer = "Report not found" // Localizer etiketi eklendi
            });
        }

        // Tüm Report kayıtlarını getirir
        [HttpGet("get-all-reports")]
        public async Task<IActionResult> GetAllReports([FromQuery] RequestParameters parameters)
        {
            var reports = await _serviceManager.ServiceReport.GetAllReportsAsync(false);
            if (reports != null)
            {
                return Ok(new
                {
                    @Localizer = "All reports fetched successfully", // Localizer etiketi eklendi
                    reports
                });
            }
            return NotFound(new
            {
                @Localizer = "No reports found" // Localizer etiketi eklendi
            });
        }

        // Report günceller
        [HttpPut("update-report")]
        public IActionResult UpdateReport([FromBody] Report report)
        {
            var existingReport = _serviceManager.ServiceReport.GetReportByIdAsync(report.ReportID, false).Result;
            if (existingReport != null)
            {
                _serviceManager.ServiceReport.UpdateReport(report);
                return Ok(new
                {
                    @Localizer = "Report updated successfully", // Localizer etiketi eklendi
                    report
                });
            }
            return NotFound(new
            {
                @Localizer = "Report not found for update" // Localizer etiketi eklendi
            });
        }

        // Report siler
        [HttpDelete("delete-report/{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            var report = await _serviceManager.ServiceReport.GetReportByIdAsync(id, false);
            if (report != null)
            {
                await _serviceManager.ServiceReport.DeleteReportAsync(id);
                return Ok(new
                {
                    @Localizer = "Report deleted successfully", // Localizer etiketi eklendi
                    report
                });
            }
            return NotFound(new
            {
                @Localizer = "Report not found for deletion" // Localizer etiketi eklendi
            });
        }

        // Sayfalama ile Report getirir
        [HttpGet("get-report-list-pagination")]
        public async Task<IActionResult> GetReportListPagination([FromQuery] RequestParameters parameters)
        {
            var reports = await _serviceManager.ServiceReport.GetPagedAndShapedReportsAsync(parameters, false);
            if (reports != null)
            {
                return Ok(new
                {
                    @Localizer = "Reports fetched with pagination", // Localizer etiketi eklendi
                    reports
                });
            }
            return NotFound(new
            {
                @Localizer = "No reports found with pagination" // Localizer etiketi eklendi
            });
        }
    }
}
