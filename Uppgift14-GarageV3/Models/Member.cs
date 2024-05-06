namespace Uppgift14_GarageV3.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string PersonNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; } = new List<ParkedVehicle>();
    }
}
