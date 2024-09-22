using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class ReportSharingDto
    {
        public Guid ShareID { get; set; }
        public string PermissionLevel { get; set; }
        public Guid ReportID { get; set; } // Foreign key
        public Guid SiteID { get; set; } // Foreign key
    }
}
