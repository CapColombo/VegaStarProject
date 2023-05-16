using MediatR;
using OneOf.Types;
using VegaStarProject.Models;

namespace VegaStarProject.Application.Employees.Commands.AddEmployee;

internal sealed class CommandHandler : IRequestHandler<AddEmployeeCommand, AddEmployeeCommandResult>
{
    private readonly WorkContext _context;

    public CommandHandler(WorkContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<AddEmployeeCommandResult> Handle(
        AddEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.EmployeeDto;

        WorkPlace? workPlace = dto.WorkplaceId is not null
            ? workPlace = _context.WorkPlaces
                .FirstOrDefault(workPlace => workPlace.Id == dto.WorkplaceId)
            : null;

        Employee employee = new(dto.FullName, dto.Age, dto.ExperienceYears, workPlace);

        try
        {
            await _context.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new AddEmployeeCommandResult(new Success());
        }
        catch (Exception)
        {
            return new AddEmployeeCommandResult(new Error());
        }
    }
}
