using System.ComponentModel.DataAnnotations;

namespace Uppgift14_GarageV3.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Personal number is required.")]
        [RegularExpression(@"^\d{6}[-+]\d{4}$", ErrorMessage = "Invalid personal number format.")]
        public string PersonNumber { get; set; } = string.Empty;
        [Required]

        public string FirstName { get; set; } = string.Empty;
        [Required]

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }
        public bool IsValid()
        {
            return Age >= 18 && FirstName != LastName;
        }
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; } = new List<ParkedVehicle>();
    }
}
