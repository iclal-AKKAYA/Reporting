using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ConnectionSite
    {
        [Key]
        public Guid SiteID { get; set; }

        public string SiteName { get; set; }
        public string IdentityProvider { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation property for ReportSharing
        public ICollection<ReportSharing> ReportSharings { get; set; }

    }
}
