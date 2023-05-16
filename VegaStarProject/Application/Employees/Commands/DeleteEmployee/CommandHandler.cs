using MediatR;
using OneOf.Types;

namespace VegaStarProject.Application.Employees.Commands.DeleteEmployee;

internal sealed class CommandHandler : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeCommandResult>
{
    private readonly WorkContext _context;

    public CommandHandler(WorkContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteEmployeeCommandResult> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        string id = request.Id;
        var employeeToRemove = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employeeToRemove != null)
        {
            try
            {
                _context.Employees.Remove(employeeToRemove);
                await _context.SaveChangesAsync();
                return new DeleteEmployeeCommandResult(new Success());
            }
            catch (Exception)
            {
                return new DeleteEmployeeCommandResult(new Error());
            }
        }
        else
        {
            return new DeleteEmployeeCommandResult(new NotFound());
        }
    }
}
