using Microsoft.AspNetCore.Mvc;
using Uppgift14_GarageV3.Helpers;
using Uppgift14_GarageV3.Models;

namespace Uppgift14_GarageV3.ViewModels
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class VehicleSummaryViewModel
    {
        public int ParkedVehicleId { get; init; }
        public int VehicleTypeID { get; init; }
        public VehicleType? VehicleType { get; init; }
        public string RegistrationNumber { get; init; } = string.Empty;
        public DateTime ArrivalTime { get; init; }

        public TimeSpan TotalParkingTime =>
            HelperFunctions.ParkedTimeAmount(ArrivalTime);

        // Empty constructor if still needed somewhere in the future
        public VehicleSummaryViewModel() { }

        /// <summary>
        /// Create a view model directly from a ParkedVehicle instance.
        /// </summary>
        /// <param name="vehicle">The ParkedVehicle to view.</param>
        public VehicleSummaryViewModel(ParkedVehicle vehicle)
        {
            ParkedVehicleId = vehicle.ParkedVehicleId;
            VehicleTypeID = vehicle.VehicleTypeID;
            VehicleType = vehicle.VehicleType;
            RegistrationNumber = vehicle.RegistrationNumber;
            ArrivalTime = vehicle.ArrivalTime;
        }
    }
}
