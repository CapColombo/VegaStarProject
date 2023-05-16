using MediatR;
using OneOf.Types;
using VegaStarProject.Models;

namespace VegaStarProject.Application.Employees.Commands.AddWorkplace;

internal sealed class CommandHandler : IRequestHandler<AddWorkplaceCommand, AddWorkplaceCommandResult>
{
    private readonly WorkContext _context;

    public CommandHandler(WorkContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<AddWorkplaceCommandResult> Handle(
        AddWorkplaceCommand request,
        CancellationToken cancellationToken)
    {
        var dto = request.WorkPlaceDto;
        WorkPlace workplace = new(dto.Name, dto.ComputerNumber);

        try
        {
            await _context.WorkPlaces.AddAsync(workplace, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new AddWorkplaceCommandResult(new Success());
        }
        catch (Exception)
        {
            return new AddWorkplaceCommandResult(new Error());
        }
    }
}
