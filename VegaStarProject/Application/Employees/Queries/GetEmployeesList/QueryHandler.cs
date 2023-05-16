using MediatR;
using Microsoft.EntityFrameworkCore;
using VegaStarProject.Application.Employees.Queries.GetEmployeesList.Data;

namespace VegaStarProject.Application.Employees.Queries.GetEmployeesList;

internal sealed class QueryHandler : IRequestHandler<GetEmployeesListQuery, GetEmployeesListQueryResult>
{
    private readonly WorkContext _context;

    public QueryHandler(WorkContext context)
    {
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetEmployeesListQueryResult> Handle(
        GetEmployeesListQuery request,
        CancellationToken cancellationToken)
    {
        var employees = _context.Employees
            .AsNoTracking()
            .Include(e => e.WorkPlace);

        List<EmployeeTableDto> dto = new();

        await employees.ForEachAsync(employee =>
            dto.Add(new EmployeeTableDto()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Age = employee.Age,
                ExperienceYears = employee.ExperienceYears,
                WorkplaceName = employee.WorkPlace?.Name,
                ComputerNumber = employee.WorkPlace?.ComputerNumber,
            }), cancellationToken: cancellationToken);

        return new GetEmployeesListQueryResult(dto);
    }
}
