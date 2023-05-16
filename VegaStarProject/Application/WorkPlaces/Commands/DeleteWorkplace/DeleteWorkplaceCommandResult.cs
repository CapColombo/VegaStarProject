using OneOf.Types;
using OneOf;
using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.DeleteWorkplace;

internal sealed class DeleteWorkplaceCommandResult : ICommandResult<OneOf<Success, NotFound, Error>>
{
    public DeleteWorkplaceCommandResult(OneOf<Success, NotFound, Error> result)
    {
        Result = result;
    }

    public OneOf<Success, NotFound, Error> Result { get; }
}
