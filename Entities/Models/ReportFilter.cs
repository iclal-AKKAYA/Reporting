using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ReportFilter
    {
        [Key]
        public Guid FilterID { get; set; }

        public string FieldName { get; set; }
        public string FilterType { get; set; }
        public string FilterValue { get; set; }

        // Foreign key for Report
        public Guid ReportID { get; set; }
        [ForeignKey("ReportID")]
        public Report Report { get; set; }
    }
}
