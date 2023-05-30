﻿using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        //private readonly ICurrentUserService _currentUserService;
        public PerformanceBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer=new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            //if response time is exceeding threshold value
            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds> 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogWarning(
                    $"Trail record system Long Running Request: {requestName} with {elapsedMilliseconds} milliseconds for Request: {request}");
            }

            return response;
    }
        }
}
