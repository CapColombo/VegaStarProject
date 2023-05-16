using MediatR;

namespace VegaStarProject.Application.Employees.Commands.EditEmployee;

internal sealed class CommandHandler : IRequestHandler<EditEmployeeCommand, EditEmployeeCommandResult>
{
    public Task<EditEmployeeCommandResult> Handle(
        EditEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
