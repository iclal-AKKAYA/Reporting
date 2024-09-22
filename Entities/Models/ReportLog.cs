using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ReportLog
    {
        [Key]
        public Guid LogID { get; set; }

        public string ActionType { get; set; }
        public DateTime ActionDate { get; set; }

        // Foreign key for Report
        public Guid ReportID { get; set; }
        [ForeignKey("ReportID")]
        public Report Report { get; set; }
    }
}
