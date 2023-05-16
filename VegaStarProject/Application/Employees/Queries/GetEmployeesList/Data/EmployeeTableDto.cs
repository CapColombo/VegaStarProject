namespace VegaStarProject.Application.Employees.Queries.GetEmployeesList.Data;

public class EmployeeTableDto
{
    public string Id { get; set; }

    public string FullName { get; set; }

    public int? Age { get; set; }

    public int? ExperienceYears { get; set; }

    public string? WorkplaceName { get; set; }

    public int? ComputerNumber { get; set; }
}
