using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class ReportLogDto
    {
        public Guid LogID { get; set; }
        public string ActionType { get; set; }
        public DateTime ActionDate { get; set; }
        public Guid ReportID { get; set; } // Foreign key
    }
}
