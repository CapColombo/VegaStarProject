using MediatR;

namespace Roads.Application.Base.Command
{
    public interface ICommand<out TCommandResult>
        : IRequest<TCommandResult> where TCommandResult : ICommandResultBase
    {
    }
}
