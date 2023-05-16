using OneOf.Types;
using OneOf;
using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.DeleteEmployee;

internal sealed class DeleteEmployeeCommandResult : ICommandResult<OneOf<Success, NotFound, Error>>
{
    public DeleteEmployeeCommandResult(OneOf<Success, NotFound, Error> result)
    {
        Result = result;
    }

    public OneOf<Success, NotFound, Error> Result { get; }
}
