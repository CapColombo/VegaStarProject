using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.DeleteWorkplace;

internal sealed class DeleteWorkplaceCommand : ICommand<DeleteWorkplaceCommandResult>
{
    public DeleteWorkplaceCommand(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}
