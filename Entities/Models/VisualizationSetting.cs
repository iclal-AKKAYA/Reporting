using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class VisualizationSetting
    {
        [Key]
        public Guid VisualizationID { get; set; }

        public string VisualizationType { get; set; }
        public string XAxisField { get; set; }
        public string YAxisField { get; set; }
        public string AggregationType { get; set; }

        // Foreign key for Report
        public Guid ReportID { get; set; }
        [ForeignKey("ReportID")]
        public Report Report { get; set; }
    }
}
