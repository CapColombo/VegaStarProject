using MediatR;
using Microsoft.EntityFrameworkCore;
using VegaStarProject.Controllers.WorkPlaces.Data;

namespace VegaStarProject.Application.Employees.Queries.GetWorkplacesList;

internal sealed class QueryHandler : IRequestHandler<GetWorkplacesListQuery, GetWorkplacesListQueryResult>
{
    private readonly WorkContext _context;

    public QueryHandler(WorkContext context)
    {
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetWorkplacesListQueryResult> Handle(
        GetWorkplacesListQuery request,
        CancellationToken cancellationToken)
    {
        var workplaces = _context.WorkPlaces.AsNoTracking();
        List<WorkplaceDto> dtos = new();

        await workplaces.ForEachAsync(w => 
            dtos.Add(new WorkplaceDto
            { 
                Id = w.Id,
                Name = w.Name,
                ComputerNumber = w.ComputerNumber 
            }),
            cancellationToken: cancellationToken);

        return new GetWorkplacesListQueryResult(dtos);
    }
}
