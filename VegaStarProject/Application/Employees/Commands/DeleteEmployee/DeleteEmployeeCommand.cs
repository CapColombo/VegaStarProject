using Roads.Application.Base.Command;

namespace VegaStarProject.Application.Employees.Commands.DeleteEmployee;

internal sealed class DeleteEmployeeCommand : ICommand<DeleteEmployeeCommandResult>
{
    public DeleteEmployeeCommand(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}
