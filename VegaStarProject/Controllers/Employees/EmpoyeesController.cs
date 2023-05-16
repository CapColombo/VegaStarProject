using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using VegaStarProject.Application.Employees.Commands.AddEmployee;
using VegaStarProject.Application.Employees.Commands.DeleteEmployee;
using VegaStarProject.Application.Employees.Commands.EditEmployee;
using VegaStarProject.Application.Employees.Queries.GetEmployeesArchive;
using VegaStarProject.Application.Employees.Queries.GetEmployeesList;
using VegaStarProject.Controllers.Employees.Data;

namespace VegaStarProject.Controllers.Employees;

[Route("api/employees")]
public class EmpoyeesController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromServices] IMediator mediator)
    {
        GetEmployeesListQueryResult queryResult =
            await mediator.Send(new GetEmployeesListQuery());

        return Json(queryResult.Result.Value);
    }

    /// <returns>Архив с XML-файлом</returns>
    [HttpGet("download")]
    public async Task<IActionResult> GetArchive([FromServices] IMediator mediator)
    {
        GetEmployeesArchiveQueryResult queryResult =
            await mediator.Send(new GetEmployeesArchiveQuery());

        return queryResult.Result
            .Match<IActionResult>(
                data => File(data.FileContents, data.ContentType, data.Filename),
                error => NotFound());
    }

    [HttpPost("add-employee")]
    public async Task<IActionResult> AddEmployee(
        [FromServices] IMediator mediator,
        [FromBody] EmployeeDto employeeDto)
    {
        var command = new AddEmployeeCommand(employeeDto);

        AddEmployeeCommandResult commandResult = await mediator.Send(command);

        IActionResult result = commandResult
            .Result
            .Match<IActionResult>(
                success => Ok(),
                error => BadRequest());

        return result;
    }

    [HttpPut()]
    public async Task<IActionResult> EditEmployee(
        [FromServices] IMediator mediator,
        [FromBody] EmployeeDto employeeDto)
    {
        var command = new EditEmployeeCommand(employeeDto);

        EditEmployeeCommandResult commandResult = await mediator.Send(command);

        IActionResult result = commandResult
            .Result
            .Match<IActionResult>(
                success => Ok(),
                notFound => NotFound(),
                error => BadRequest());

        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(
        [FromServices] IMediator mediator,
        [FromRoute] string id)
    {
        var command = new DeleteEmployeeCommand(id);

        DeleteEmployeeCommandResult commandResult = await mediator.Send(command);

        IActionResult result = commandResult
            .Result
            .Match<IActionResult>(
                success => Ok(),
                notFound => NotFound(),
                error => BadRequest());

        return result;
    }
}
