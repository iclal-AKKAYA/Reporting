using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class DataSourceDto
    {
        public Guid SourceID { get; set; }
        public string SourceName { get; set; }
        public string MongoDBCollection { get; set; }
        public string ElasticIndex { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
