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
    public class DataSourceController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DataSourceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // Yeni bir DataSource ekler
        [HttpPost("add-datasource")]
        public async Task<IActionResult> AddDataSource([FromBody] DataSource dataSource)
        {
            await _serviceManager.ServiceDataSource.CreateDataSourceAsync(dataSource);
            return Ok(new
            {
                @Localizer = "DataSource added successfully", // Localizer etiketi eklendi
                dataSource
            });
        }

        // ID'ye göre bir DataSource getirir
        [HttpGet("get-datasource-by-id/{id}")]
        public async Task<IActionResult> GetDataSource(Guid id)
        {
            var dataSource = await _serviceManager.ServiceDataSource.GetDataSourceByIdAsync(id, false);
            if (dataSource != null)
            {
                return Ok(new
                {
                    @Localizer = "DataSource fetched successfully", // Localizer etiketi eklendi
                    dataSource
                });
            }
            return NotFound(new
            {
                @Localizer = "DataSource not found" // Localizer etiketi eklendi
            });
        }

        // Tüm DataSource kayıtlarını getirir
        [HttpGet("get-all-datasources")]
        public async Task<IActionResult> GetAllDataSources([FromQuery] RequestParameters parameters)
        {
            var dataSources = await _serviceManager.ServiceDataSource.GetAllDataSourcesAsync(false);
            if (dataSources != null)
            {
                return Ok(new
                {
                    @Localizer = "All DataSources fetched successfully", // Localizer etiketi eklendi
                    dataSources
                });
            }
            return NotFound(new
            {
                @Localizer = "No DataSources found" // Localizer etiketi eklendi
            });
        }

        // DataSource günceller
        [HttpPut("update-datasource")]
        public IActionResult UpdateDataSource([FromBody] DataSource dataSource)
        {
            var existingDataSource = _serviceManager.ServiceDataSource.GetDataSourceByIdAsync(dataSource.SourceID, false).Result;
            if (existingDataSource != null)
            {
                _serviceManager.ServiceDataSource.UpdateDataSource(dataSource);
                return Ok(new
                {
                    @Localizer = "DataSource updated successfully", // Localizer etiketi eklendi
                    dataSource
                });
            }
            return NotFound(new
            {
                @Localizer = "DataSource not found for update" // Localizer etiketi eklendi
            });
        }

        // DataSource siler
        [HttpDelete("delete-datasource/{id}")]
        public async Task<IActionResult> DeleteDataSource(Guid id)
        {
            var dataSource = await _serviceManager.ServiceDataSource.GetDataSourceByIdAsync(id, false);
            if (dataSource != null)
            {
                await _serviceManager.ServiceDataSource.DeleteDataSourceAsync(id);
                return Ok(new
                {
                    @Localizer = "DataSource deleted successfully", // Localizer etiketi eklendi
                    dataSource
                });
            }
            return NotFound(new
            {
                @Localizer = "DataSource not found for deletion" // Localizer etiketi eklendi
            });
        }

        // Sayfalama ile DataSource getirir
        [HttpGet("get-datasource-list-pagination")]
        public async Task<IActionResult> GetDataSourceListPagination([FromQuery] RequestParameters parameters)
        {
            var dataSources = await _serviceManager.ServiceDataSource.GetPagedDataSourcesAsync(parameters, false);
            if (dataSources != null)
            {
                return Ok(new
                {
                    @Localizer = "DataSources fetched with pagination", // Localizer etiketi eklendi
                    dataSources
                });
            }
            return NotFound(new
            {
                @Localizer = "No DataSources found with pagination" // Localizer etiketi eklendi
            });
        }
    }
}
