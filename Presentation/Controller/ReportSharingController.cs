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
    public class ReportSharingController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReportSharingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Tüm ReportSharing kayıtlarını getirir
        [HttpGet("get-all-report-sharings")]
        public async Task<IActionResult> GetAllReportSharings()
        {
            var reportSharings = await _serviceManager.ServiceReportSharing.GetAllReportSharingsAsync(false);
            if (reportSharings != null)
            {
                return Ok(new
                {
                    @Localizer = "Report sharings fetched successfully",
                    reportSharings
                });
            }
            return NotFound(new
            {
                @Localizer = "No report sharings found"
            });
        }

        // ID'ye göre tek bir ReportSharing getirir
        [HttpGet("get-report-sharing-by-id/{id}")]
        public async Task<IActionResult> GetReportSharing(Guid id)
        {
            var reportSharing = await _serviceManager.ServiceReportSharing.GetReportSharingByIdAsync(id, false);
            if (reportSharing != null)
            {
                return Ok(new
                {
                    @Localizer = "Report sharing fetched successfully",
                    reportSharing
                });
            }
            return NotFound(new
            {
                @Localizer = "Report sharing not found"
            });
        }

        // Yeni bir ReportSharing ekler
        [HttpPost("add-report-sharing")]
        public async Task<IActionResult> AddReportSharing([FromBody] ReportSharing reportSharing)
        {
            await _serviceManager.ServiceReportSharing.CreateReportSharingAsync(reportSharing);
            return Ok(new
            {
                @Localizer = "Report sharing added successfully",
                reportSharing
            });
        }

        // ReportSharing günceller
        [HttpPut("update-report-sharing")]
        public IActionResult UpdateReportSharing([FromBody] ReportSharing reportSharing)
        {
            var existingReportSharing = _serviceManager.ServiceReportSharing.GetReportSharingByIdAsync(reportSharing.ShareID, false).Result;
            if (existingReportSharing != null)
            {
                _serviceManager.ServiceReportSharing.UpdateReportSharing(reportSharing);
                return Ok(new
                {
                    @Localizer = "Report sharing updated successfully",
                    reportSharing
                });
            }
            return NotFound(new
            {
                @Localizer = "Report sharing not found for update"
            });
        }

        // ReportSharing siler
        [HttpDelete("delete-report-sharing/{id}")]
        public async Task<IActionResult> DeleteReportSharing(Guid id)
        {
            var reportSharing = await _serviceManager.ServiceReportSharing.GetReportSharingByIdAsync(id, false);
            if (reportSharing != null)
            {
                _serviceManager.ServiceReportSharing.DeleteReportSharing(id);
                return Ok(new
                {
                    @Localizer = "Report sharing deleted successfully",
                    reportSharing
                });
            }
            return NotFound(new
            {
                @Localizer = "Report sharing not found for deletion"
            });
        }
    }
}
