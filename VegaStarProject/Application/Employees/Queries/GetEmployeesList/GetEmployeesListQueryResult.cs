using OneOf;
using Roads.Application.Base.Queries;
using VegaStarProject.Application.Employees.Queries.GetEmployeesList.Data;

namespace VegaStarProject.Application.Employees.Queries.GetEmployeesList;

internal sealed class GetEmployeesListQueryResult : IQueryResult<OneOf<IEnumerable<EmployeeTableDto>>>
{
    public GetEmployeesListQueryResult(OneOf<IEnumerable<EmployeeTableDto>> result)
    {
        Result = result;
    }

    public OneOf<IEnumerable<EmployeeTableDto>> Result { get; }
}
