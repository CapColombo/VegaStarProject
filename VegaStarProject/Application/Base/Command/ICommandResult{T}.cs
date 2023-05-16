using OneOf;

namespace Roads.Application.Base.Command
{
    public interface ICommandResult<T> : ICommandResultBase where T : IOneOf
    {
        T Result { get; }
    }
}
