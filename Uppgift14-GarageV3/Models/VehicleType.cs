using System.ComponentModel.DataAnnotations;

namespace Uppgift14_GarageV3;

[DisplayColumn("Name")]
public class VehicleType
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int NumSpacesNeededToPark { get; set; }
    public int NumberOfWheels { get; set; }
}
