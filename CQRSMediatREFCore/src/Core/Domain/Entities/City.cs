using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain
{
    public class City:BaseAuditableEntity
    {
        public string Name { get; set; }
    }
}
