﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Events
{
    public interface IEventBus
    {
        Task FlushAllAsync(CancellationToken cancellationToken);
    }
}
