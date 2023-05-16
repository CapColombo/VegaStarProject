using MediatR;
using OneOf.Types;

namespace VegaStarProject.Application.Employees.Commands.DeleteWorkplace;

internal sealed class CommandHandler : IRequestHandler<DeleteWorkplaceCommand, DeleteWorkplaceCommandResult>
{
    private readonly WorkContext _context;

    public CommandHandler(WorkContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteWorkplaceCommandResult> Handle(
        DeleteWorkplaceCommand request,
        CancellationToken cancellationToken)
    {
        string id = request.Id;
        var workplaceToRemove = _context.WorkPlaces.FirstOrDefault(w => w.Id == id);

        if (workplaceToRemove == null)
        {
            return new DeleteWorkplaceCommandResult(new NotFound());
        }

        try
        {
            _context.WorkPlaces.Remove(workplaceToRemove);
            await _context.SaveChangesAsync(cancellationToken);
            return new DeleteWorkplaceCommandResult(new Success());
        }
        catch (Exception)
        {
            return new DeleteWorkplaceCommandResult(new Error());
        }
    }
}
