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
    public class ConnectionSiteController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ConnectionSiteController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Yeni bir ConnectionSite ekler
        [HttpPost("add-connectionsite")]
        public async Task<IActionResult> AddConnectionSite([FromBody] ConnectionSite connectionSite)
        {
            await _serviceManager.ServiceConnectionSite.CreateConnectionSiteAsync(connectionSite);
            return Ok(new
            {
                @Localizer = "ConnectionSite added successfully", // Localizer etiketi eklendi
                connectionSite
            });
        }

        // ID'ye göre bir ConnectionSite getirir
        [HttpGet("get-connectionsite-by-id/{id}")]
        public async Task<IActionResult> GetConnectionSite(Guid id)
        {
            var connectionSite = await _serviceManager.ServiceConnectionSite.GetConnectionSiteByIdAsync(id, false);
            if (connectionSite != null)
            {
                return Ok(new
                {
                    @Localizer = "ConnectionSite fetched successfully", // Localizer etiketi eklendi
                    connectionSite
                });
            }
            return NotFound(new
            {
                @Localizer = "ConnectionSite not found" // Localizer etiketi eklendi
            });
        }

        // Tüm ConnectionSite kayıtlarını getirir
        [HttpGet("get-all-connection-sites")]
        public async Task<IActionResult> GetAllConnectionSites([FromQuery] RequestParameters parameters)
        {
            var connectionSites = await _serviceManager.ServiceConnectionSite.GetAllConnectionSitesAsync(false);
            if (connectionSites != null)
            {
                return Ok(new
                {
                    @Localizer = "All ConnectionSites fetched successfully", // Localizer etiketi eklendi
                    connectionSites
                });
            }
            return NotFound(new
            {
                @Localizer = "No ConnectionSites found" // Localizer etiketi eklendi
            });
        }

        // ConnectionSite günceller
        [HttpPut("update-connectionsite")]
        public IActionResult UpdateConnectionSite([FromBody] ConnectionSite connectionSite)
        {
            var existingConnectionSite = _serviceManager.ServiceConnectionSite.GetConnectionSiteByIdAsync(connectionSite.SiteID, false).Result;
            if (existingConnectionSite != null)
            {
                _serviceManager.ServiceConnectionSite.UpdateConnectionSite(connectionSite);
                return Ok(new
                {
                    @Localizer = "ConnectionSite updated successfully", // Localizer etiketi eklendi
                    connectionSite
                });
            }
            return NotFound(new
            {
                @Localizer = "ConnectionSite not found for update" // Localizer etiketi eklendi
            });
        }

        // ConnectionSite siler
        [HttpDelete("delete-connectionsite/{id}")]
        public async Task<IActionResult> DeleteConnectionSite(Guid id)
        {
            var connectionSite = await _serviceManager.ServiceConnectionSite.GetConnectionSiteByIdAsync(id, false);
            if (connectionSite != null)
            {
                _serviceManager.ServiceConnectionSite.DeleteConnectionSite(connectionSite);
                return Ok(new
                {
                    @Localizer = "ConnectionSite deleted successfully", // Localizer etiketi eklendi
                    connectionSite
                });
            }
            return NotFound(new
            {
                @Localizer = "ConnectionSite not found for deletion" // Localizer etiketi eklendi
            });
        }

        // Sayfalama ile ConnectionSite getirir
        [HttpGet("get-connectionsite-list-pagination")]
        public async Task<IActionResult> GetConnectionSiteListPagination([FromQuery] RequestParameters parameters)
        {
            var connectionSites = await _serviceManager.ServiceConnectionSite.GetPagedConnectionSitesAsync(parameters, false);
            if (connectionSites != null)
            {
                return Ok(new
                {
                    @Localizer = "ConnectionSites fetched with pagination", // Localizer etiketi eklendi
                    connectionSites
                });
            }
            return NotFound(new
            {
                @Localizer = "No ConnectionSites found with pagination" // Localizer etiketi eklendi
            });
        }
    }
}
