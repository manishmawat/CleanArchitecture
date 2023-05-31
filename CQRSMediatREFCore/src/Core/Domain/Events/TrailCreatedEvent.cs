using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Events
{
    public class TrailCreatedEvent : BaseEvent
    {
        public TrailCreatedEvent(Trail trail)
        {
            Trail = trail;
        }

        public Trail Trail { get; }
    }
}
