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
    public class ReportFilterController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ReportFilterController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Yeni bir ReportFilter ekler
        [HttpPost("add-reportfilter")]
        public async Task<IActionResult> AddReportFilter([FromBody] ReportFilter reportFilter)
        {
            await _serviceManager.ServiceReportFilter.CreateReportFilterAsync(reportFilter);
            return Ok(new
            {
                @Localizer = "ReportFilter added successfully", // Localizer etiketi eklendi
                reportFilter
            });
        }

        // ID'ye göre bir ReportFilter getirir
        [HttpGet("get-reportfilter-by-id/{id}")]
        public async Task<IActionResult> GetReportFilter(Guid id)
        {
            var reportFilter = await _serviceManager.ServiceReportFilter.GetReportFilterByIdAsync(id, false);
            if (reportFilter != null)
            {
                return Ok(new
                {
                    @Localizer = "ReportFilter fetched successfully", // Localizer etiketi eklendi
                    reportFilter
                });
            }
            return NotFound(new
            {
                @Localizer = "ReportFilter not found" // Localizer etiketi eklendi
            });
        }

        // Tüm ReportFilter kayıtlarını getirir
        [HttpGet("get-all-reportfilters")]
        public async Task<IActionResult> GetAllReportFilters([FromQuery] RequestParameters parameters)
        {
            var reportFilters = await _serviceManager.ServiceReportFilter.GetAllReportFiltersAsync(false);
            if (reportFilters != null)
            {
                return Ok(new
                {
                    @Localizer = "All ReportFilters fetched successfully", // Localizer etiketi eklendi
                    reportFilters
                });
            }
            return NotFound(new
            {
                @Localizer = "No ReportFilters found" // Localizer etiketi eklendi
            });
        }

        // ReportFilter günceller
        [HttpPut("update-reportfilter")]
        public IActionResult UpdateReportFilter([FromBody] ReportFilter reportFilter)
        {
            var existingReportFilter = _serviceManager.ServiceReportFilter.GetReportFilterByIdAsync(reportFilter.FilterID, false).Result;
            if (existingReportFilter != null)
            {
                _serviceManager.ServiceReportFilter.UpdateReportFilter(reportFilter);
                return Ok(new
                {
                    @Localizer = "ReportFilter updated successfully", // Localizer etiketi eklendi
                    reportFilter
                });
            }
            return NotFound(new
            {
                @Localizer = "ReportFilter not found for update" // Localizer etiketi eklendi
            });
        }

        // ReportFilter siler
        [HttpDelete("delete-reportfilter/{id}")]
        public async Task<IActionResult> DeleteReportFilter(Guid id)
        {
            var reportFilter = await _serviceManager.ServiceReportFilter.GetReportFilterByIdAsync(id, false);
            if (reportFilter != null)
            {
                await _serviceManager.ServiceReportFilter.DeleteReportFilterAsync(id);
                return Ok(new
                {
                    @Localizer = "ReportFilter deleted successfully", // Localizer etiketi eklendi
                    reportFilter
                });
            }
            return NotFound(new
            {
                @Localizer = "ReportFilter not found for deletion" // Localizer etiketi eklendi
            });
        }

        // Sayfalama ile ReportFilter getirir
        [HttpGet("get-reportfilter-list-pagination")]
        public async Task<IActionResult> GetReportFilterListPagination([FromQuery] RequestParameters parameters)
        {
            var reportFilters = await _serviceManager.ServiceReportFilter.GetPagedReportFiltersAsync(parameters, false);
            if (reportFilters != null)
            {
                return Ok(new
                {
                    @Localizer = "ReportFilters fetched with pagination", // Localizer etiketi eklendi
                    reportFilters
                });
            }
            return NotFound(new
            {
                @Localizer = "No ReportFilters found with pagination" // Localizer etiketi eklendi
            });
        }
    }
}
