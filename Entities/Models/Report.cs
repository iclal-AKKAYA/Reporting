using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Report
    {
        [Key]
        public Guid ReportID { get; set; }

        public string ReportName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DataSource { get; set; }
        public string FilterCriteria { get; set; }
        public string VisualizationType { get; set; }
        public string Query { get; set; }

        // Navigation properties for relationships
        public ICollection<ReportFilter> ReportFilters { get; set; }
        public ICollection<VisualizationSetting> VisualizationSettings { get; set; }
        public ICollection<ReportSharing> ReportSharings { get; set; }
        public ICollection<ReportLog> ReportLogs { get; set; }
    }
}
