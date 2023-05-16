using Roads.Application.Base.Command;
using VegaStarProject.Controllers.Employees.Data;

namespace VegaStarProject.Application.Employees.Commands.EditEmployee;

internal sealed class EditEmployeeCommand : ICommand<EditEmployeeCommandResult>
{
    public EditEmployeeCommand(EmployeeDto employeeDto)
    {
        EmployeeDto = employeeDto;
    }

    public EmployeeDto EmployeeDto { get; set; }
}
