using OneOf.Types;
using OneOf;
using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.AddWorkplace;

internal sealed class AddWorkplaceCommandResult : ICommandResult<OneOf<Success, Error>>
{
    public AddWorkplaceCommandResult(OneOf<Success, Error> result)
    {
        Result = result;
    }

    public OneOf<Success, Error> Result { get; }
}
