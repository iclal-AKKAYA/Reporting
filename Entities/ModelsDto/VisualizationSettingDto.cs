using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class VisualizationSettingDto
    {
        public Guid VisualizationID { get; set; }
        public string VisualizationType { get; set; }
        public string XAxisField { get; set; }
        public string YAxisField { get; set; }
        public string AggregationType { get; set; }
        public Guid ReportID { get; set; } // Foreign key
    }
}
