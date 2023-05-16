using MediatR;
using Microsoft.AspNetCore.Mvc;
using VegaStarProject.Application.Employees.Commands.AddWorkplace;
using VegaStarProject.Application.Employees.Commands.DeleteWorkplace;
using VegaStarProject.Application.Employees.Queries.GetWorkplacesList;
using VegaStarProject.Controllers.WorkPlaces.Data;

namespace VegaStarProject.Controllers.WorkPlaces;

[Route("api/workplaces")]
public class WorkPlaceController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromServices] IMediator mediator)
    {
        GetWorkplacesListQueryResult queryResult =
            await mediator.Send(new GetWorkplacesListQuery());

        return Json(queryResult.Result.Value);
    }

    [HttpPost("add-workplace")]
    public async Task<IActionResult> AddWorkplace(
        [FromServices] IMediator mediator,
        [FromBody] WorkplaceDto workPlaceDto)
    {
        var command = new AddWorkplaceCommand(workPlaceDto);

        AddWorkplaceCommandResult commandResult = await mediator.Send(command);

        IActionResult result = commandResult
            .Result
            .Match<IActionResult>(
                success => Ok(),
                error => BadRequest());

        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkplace(
        [FromServices] IMediator mediator,
        [FromRoute] string id)
    {
        var command = new DeleteWorkplaceCommand(id);

        DeleteWorkplaceCommandResult commandResult = await mediator.Send(command);

        IActionResult result = commandResult
            .Result
            .Match<IActionResult>(
                success => Ok(),
                notFound => NotFound(),
                error => BadRequest());

        return result;
    }
}
