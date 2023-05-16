using MediatR;

namespace Roads.Application.Base.Queries
{
    public interface IQuery<out TQueryResult>
        : IRequest<TQueryResult> where TQueryResult : IQueryResultBase
    {

    }
}
