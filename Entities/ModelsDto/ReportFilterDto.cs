using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class ReportFilterDto
    {
        public Guid FilterID { get; set; }
        public string FieldName { get; set; }
        public string FilterType { get; set; }
        public string FilterValue { get; set; }
        public Guid ReportID { get; set; } // Foreign key
    }
}
