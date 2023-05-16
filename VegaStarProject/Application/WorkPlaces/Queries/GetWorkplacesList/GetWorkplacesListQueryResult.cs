using OneOf;
using Roads.Application.Base.Queries;
using VegaStarProject.Controllers.WorkPlaces.Data;

namespace VegaStarProject.Application.Employees.Queries.GetWorkplacesList;

internal sealed class GetWorkplacesListQueryResult : IQueryResult<OneOf<IEnumerable<WorkplaceDto>>>
{
    public GetWorkplacesListQueryResult(OneOf<IEnumerable<WorkplaceDto>> result)
    {
        Result = result;
    }

    public OneOf<IEnumerable<WorkplaceDto>> Result { get; }
}
