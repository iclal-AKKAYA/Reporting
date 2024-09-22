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
    public class VisualizationSettingController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public VisualizationSettingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Yeni bir VisualizationSetting ekler
        [HttpPost("add-visualizationsetting")]
        public async Task<IActionResult> AddVisualizationSetting([FromBody] VisualizationSetting visualizationSetting)
        {
            await _serviceManager.ServiceVisualizationSetting.CreateVisualizationSettingAsync(visualizationSetting);
            return Ok(new
            {
                @Localizer = "VisualizationSetting added successfully", // Localizer etiketi eklendi
                visualizationSetting
            });
        }

        // ID'ye göre bir VisualizationSetting getirir
        [HttpGet("get-visualizationsetting-by-id/{id}")]
        public async Task<IActionResult> GetVisualizationSetting(Guid id)
        {
            var visualizationSetting = await _serviceManager.ServiceVisualizationSetting.GetVisualizationSettingByIdAsync(id, false);
            if (visualizationSetting != null)
            {
                return Ok(new
                {
                    @Localizer = "VisualizationSetting fetched successfully", // Localizer etiketi eklendi
                    visualizationSetting
                });
            }
            return NotFound(new
            {
                @Localizer = "VisualizationSetting not found" // Localizer etiketi eklendi
            });
        }

        // Tüm VisualizationSetting kayıtlarını getirir
        [HttpGet("get-all-visualizationsettings")]
        public async Task<IActionResult> GetAllVisualizationSettings([FromQuery] RequestParameters parameters)
        {
            var visualizationSettings = await _serviceManager.ServiceVisualizationSetting.GetAllVisualizationSettingsAsync(false);
            if (visualizationSettings != null)
            {
                return Ok(new
                {
                    @Localizer = "All VisualizationSettings fetched successfully", // Localizer etiketi eklendi
                    visualizationSettings
                });
            }
            return NotFound(new
            {
                @Localizer = "No VisualizationSettings found" // Localizer etiketi eklendi
            });
        }

        // VisualizationSetting günceller
        [HttpPut("update-visualizationsetting")]
        public IActionResult UpdateVisualizationSetting([FromBody] VisualizationSetting visualizationSetting)
        {
            var existingVisualizationSetting = _serviceManager.ServiceVisualizationSetting.GetVisualizationSettingByIdAsync(visualizationSetting.VisualizationID, false).Result;
            if (existingVisualizationSetting != null)
            {
                _serviceManager.ServiceVisualizationSetting.UpdateVisualizationSetting(visualizationSetting);
                return Ok(new
                {
                    @Localizer = "VisualizationSetting updated successfully", // Localizer etiketi eklendi
                    visualizationSetting
                });
            }
            return NotFound(new
            {
                @Localizer = "VisualizationSetting not found for update" // Localizer etiketi eklendi
            });
        }

        // VisualizationSetting siler
        [HttpDelete("delete-visualizationsetting/{id}")]
        public async Task<IActionResult> DeleteVisualizationSetting(Guid id)
        {
            var visualizationSetting = await _serviceManager.ServiceVisualizationSetting.GetVisualizationSettingByIdAsync(id, false);
            if (visualizationSetting != null)
            {
                await _serviceManager.ServiceVisualizationSetting.DeleteVisualizationSettingAsync(id);
                return Ok(new
                {
                    @Localizer = "VisualizationSetting deleted successfully", // Localizer etiketi eklendi
                    visualizationSetting
                });
            }
            return NotFound(new
            {
                @Localizer = "VisualizationSetting not found for deletion" // Localizer etiketi eklendi
            });
        }

        // Sayfalama ile VisualizationSetting getirir
        [HttpGet("get-visualizationsetting-list-pagination")]
        public async Task<IActionResult> GetVisualizationSettingListPagination([FromQuery] RequestParameters parameters)
        {
            var visualizationSettings = await _serviceManager.ServiceVisualizationSetting.GetPagedVisualizationSettingsAsync(parameters, false);
            if (visualizationSettings != null)
            {
                return Ok(new
                {
                    @Localizer = "VisualizationSettings fetched with pagination", // Localizer etiketi eklendi
                    visualizationSettings
                });
            }
            return NotFound(new
            {
                @Localizer = "No VisualizationSettings found with pagination" // Localizer etiketi eklendi
            });
        }
    }
}
