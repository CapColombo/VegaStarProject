namespace VegaStarProject.Application.Employees.Queries.GetEmployeesList.Data;

public class EmployeeArchiveDto
{
    public string Filename { get; set; }

    public byte[] FileContents { get; set; }

    public string ContentType { get; set; }
}
