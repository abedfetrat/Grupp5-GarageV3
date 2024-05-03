using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift14_GarageV3.Models
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class ParkedVehicle
    {
        public int ParkedVehicleId { get; set; }
        public int VehicleTypeID { get; set; }
        public VehicleType? VehicleType { get; set; }

        [StringLength(10)]
        public string RegistrationNumber { get; init; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        [Range(1, 18)]
        /// TODO: Retreive NumberOfWheels from VehicleType
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime { get; init; } = DateTime.Now;

        [NotMapped]
        public TimeSpan TotalParkingTime
        {
            get => Helpers.HelperFunctions.ParkedTimeAmount(ArrivalTime);
        }
    }
}