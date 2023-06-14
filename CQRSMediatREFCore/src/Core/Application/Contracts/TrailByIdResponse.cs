using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public class TrailByIdResponse
    {
        public string TrailName { get; set; }
        public string TrailDescription { get; set; }
        public double Distance { get; set; }
        public string CityName { get; set; }
    }
}
