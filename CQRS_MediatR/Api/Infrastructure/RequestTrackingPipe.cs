using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Services;

namespace Api.Infrastructure
 {
    public class RequestTrackingPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            if (request is BaseRequest br) br.RequestedAt = DateTime.Now;

            return await next();
        }
    }
}