using OneOf;

namespace Roads.Application.Base.Queries
{
    public interface IQueryResult<T> : IQueryResultBase where T : IOneOf
    {
        T Result { get; }
    }
}
