using Roads.Application.Base.Command;
using VegaStarProject.Controllers.WorkPlaces.Data;

namespace VegaStarProject.Application.Employees.Commands.AddWorkplace;

internal sealed class AddWorkplaceCommand : ICommand<AddWorkplaceCommandResult>
{
    public AddWorkplaceCommand(WorkplaceDto WorkplaceDto)
    {
        WorkPlaceDto = WorkplaceDto;
    }

    public WorkplaceDto WorkPlaceDto { get; set; }
}
