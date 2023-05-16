using System.ComponentModel.DataAnnotations;

namespace VegaStarProject.Models;

public class Employee
{
    public Employee() { }

    public Employee(string fullName, int? age, int? experienceYears, WorkPlace? workPlace)
    {
        Id = Guid.NewGuid().ToString();
        FullName = fullName;
        Age = age;
        ExperienceYears = experienceYears;
        WorkPlace = workPlace;
    }

    public string Id { get; set; }

    [Required]
    public string FullName { get; set; }

    public int? Age { get; set; }

    public int? ExperienceYears { get; set; }

    public WorkPlace? WorkPlace { get; set; }
}
