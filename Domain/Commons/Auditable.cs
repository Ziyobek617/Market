using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Commons
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get;set; }
    }
}
