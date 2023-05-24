using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain
{
    public class Trail:BaseAuditableEntity
    {
        public string TrailName { get; set; }
        public string TrailDescription { get; set;}
        public double Distance { get; set; }
        public City City { get; set; }
    }
}
