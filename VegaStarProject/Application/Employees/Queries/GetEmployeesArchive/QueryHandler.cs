using Aspose.Zip;
using Aspose.Zip.Saving;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf.Types;
using System.Text;
using System.Xml.Serialization;
using VegaStarProject.Application.Employees.Queries.GetEmployeesList.Data;

namespace VegaStarProject.Application.Employees.Queries.GetEmployeesArchive;

internal sealed class QueryHandler : IRequestHandler<GetEmployeesArchiveQuery, GetEmployeesArchiveQueryResult>
{
    private readonly WorkContext _context;
    const string FILE_NAME = "Список сотрудников";

    public QueryHandler(WorkContext context)
    {
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetEmployeesArchiveQueryResult> Handle(
        GetEmployeesArchiveQuery request,
        CancellationToken cancellationToken)
    {
        try
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

            XmlSerializer xmlSerializer = new(typeof(List<EmployeeTableDto>));
            using var memoryStream = new MemoryStream();

            xmlSerializer.Serialize(memoryStream, dto);

            using var archive = new Archive(new ArchiveEntrySettings());

            archive.CreateEntry(FILE_NAME + ".xml", memoryStream);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var outputStream = new MemoryStream();
            archive.Save(outputStream);

            var archiveDto = new EmployeeArchiveDto()
            {
                Filename = FILE_NAME + ".zip",
                FileContents = outputStream.ToArray(),
                ContentType = "application/zip"
            };

            return new GetEmployeesArchiveQueryResult(archiveDto);
        }
        catch (Exception)
        {
            return new GetEmployeesArchiveQueryResult(new Error());
        }
    }
}
