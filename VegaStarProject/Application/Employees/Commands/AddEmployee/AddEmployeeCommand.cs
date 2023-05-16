using Roads.Application.Base.Command;
using VegaStarProject.Controllers.Employees.Data;

namespace VegaStarProject.Application.Employees.Commands.AddEmployee;

internal sealed class AddEmployeeCommand : ICommand<AddEmployeeCommandResult>
{
    public AddEmployeeCommand(EmployeeDto employeeDto)
    {
        EmployeeDto = employeeDto;
    }

    public EmployeeDto EmployeeDto { get; set; }
}
