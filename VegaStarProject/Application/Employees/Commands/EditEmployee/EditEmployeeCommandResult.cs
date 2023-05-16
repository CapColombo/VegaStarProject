using OneOf.Types;
using OneOf;
using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.EditEmployee;

internal sealed class EditEmployeeCommandResult : ICommandResult<OneOf<Success, NotFound, Error>>
{
    public EditEmployeeCommandResult(OneOf<Success, NotFound, Error> result)
    {
        Result = result;
    }

    public OneOf<Success, NotFound, Error> Result { get; }
}
