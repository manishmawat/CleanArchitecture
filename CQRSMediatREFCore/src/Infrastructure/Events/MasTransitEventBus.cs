using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Events;

namespace Infrastructure.Events
{
    public class MasTransitEventBus:IEventBus
    {
        private readonly List<object> _messagesToPublish = new List<object>();
        public MasTransitEventBus()
        {
            
        }
        public Task FlushAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
