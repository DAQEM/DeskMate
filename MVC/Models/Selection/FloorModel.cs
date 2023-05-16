using BLL.Entities;

namespace MVC.Models;

public class FloorModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int FloorNumber { get; set; }

    public static FloorModel FromFloor(Floor floor)
    {
        return new FloorModel
        {
            Id = floor.Id,
            Name = floor.Name,
            FloorNumber = floor.FloorNumber
        };
    }
}