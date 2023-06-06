using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Trails.Commands.CreateTrail.Mapper
{
    public static class TrailCreatedMapper
    {
        public static TrailCreated MapTrailCreated(this Trail trail)
        {
            return new TrailCreated()
            {
                TrailName = trail.TrailName,
                TrailDescription = trail.TrailDescription,
                Distance = trail.Distance,
            };
        }
    }

    public class TrailCreated
    {
        public string TrailName { get; set; }
        public string TrailDescription { get; set; }
        public double Distance { get; set; }
    }
}
