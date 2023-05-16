using OneOf;
using OneOf.Types;
using Roads.Application.Base.Queries;
using VegaStarProject.Application.Employees.Queries.GetEmployeesList.Data;

namespace VegaStarProject.Application.Employees.Queries.GetEmployeesArchive;

internal sealed class GetEmployeesArchiveQueryResult : IQueryResult<OneOf<EmployeeArchiveDto, Error>>
{
    public GetEmployeesArchiveQueryResult(OneOf<EmployeeArchiveDto, Error> result)
    {
        Result = result;
    }

    public OneOf<EmployeeArchiveDto, Error> Result { get; }
}
