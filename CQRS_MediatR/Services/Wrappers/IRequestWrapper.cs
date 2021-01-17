using MediatR;

namespace Services.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    {}

    public interface IHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IRequestWrapper<TOut>
    {}
}