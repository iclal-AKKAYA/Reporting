using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ReportSharing
    {
        [Key]
        public Guid ShareID { get; set; }

        public string PermissionLevel { get; set; }

        // Foreign key for Report
        public Guid ReportID { get; set; }
        [ForeignKey("ReportID")]
        public Report Report { get; set; }

        // Foreign key for ConnectionSite
        public Guid SiteID { get; set; }
        [ForeignKey("SiteID")]
        public ConnectionSite ConnectionSite { get; set; }
    }
}
