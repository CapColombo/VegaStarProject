using System.ComponentModel.DataAnnotations;

namespace VegaStarProject.Models;

public class WorkPlace
{
    public WorkPlace() { }

    public WorkPlace(string name, int? computerNumber)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        ComputerNumber = computerNumber;
    }

    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int? ComputerNumber { get; set; }
}
