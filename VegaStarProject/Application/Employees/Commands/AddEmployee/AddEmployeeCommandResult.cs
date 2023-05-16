using OneOf.Types;
using OneOf;
using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.AddEmployee;

internal sealed class AddEmployeeCommandResult : ICommandResult<OneOf<Success, Error>>
{
    public AddEmployeeCommandResult(OneOf<Success, Error> result)
    {
        Result = result;
    }

    public OneOf<Success, Error> Result { get; }
}
