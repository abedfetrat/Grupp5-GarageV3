using Uppgift14_GarageV3.Models;

namespace Uppgift14_GarageV3.Data
{
    public class DbInitializer
    {
        private readonly VehicleType car = new VehicleType { Name = "Car", NumSpacesNeededToPark = 1, NumberOfWheels = 4 };
        private readonly VehicleType truck = new VehicleType { Name = "Truck", NumSpacesNeededToPark = 2, NumberOfWheels = 6 };
        private readonly VehicleType motorcycle = new VehicleType { Name = "Motorcycle", NumSpacesNeededToPark = 1, NumberOfWheels = 2 };

        private VehicleType[] SeedVehicleTypes => [car, truck, motorcycle];

        // Use today as the time reference on every instantiation
        // If it's after 10:00 AM, set this to the preceding midnight (00:00 of the current day)
        // If it's before 10:00 AM, set this to the preceding noon (12:00 of the previous day)
        private readonly DateTime _today =
            DateTime.Now.TimeOfDay > new TimeSpan(10, 00, 00) ? DateTime.Today : DateTime.Today - new TimeSpan(12, 00, 00);

        // Representative examples of vehicles that may be parked in the garage
        private ParkedVehicle[] SeedVehicles => [
            new ParkedVehicle { VehicleType = car       , RegistrationNumber = "ABC123", Color = "Beige", Make = "Toyota"       , Model = "Corolla", ArrivalTime = _today + new TimeSpan(08, 30, 00) },
            new ParkedVehicle { VehicleType = car       , RegistrationNumber = "DEF456", Color = "Gray" , Make = "Volvo"        , Model = "EC40"   , ArrivalTime = _today + new TimeSpan(09, 15, 00) },
            new ParkedVehicle { VehicleType = motorcycle, RegistrationNumber = "XYZ098", Color = "Blue" , Make = "Yamaha"       , Model = "R7"     , ArrivalTime = _today + new TimeSpan(09, 30, 00) },
            new ParkedVehicle { VehicleType = car       , RegistrationNumber = "YYZ000", Color = "Red"  , Make = "Tesla"        , Model = "Model Y", ArrivalTime = _today + new TimeSpan(09, 45, 00) },
            new ParkedVehicle { VehicleType = truck     , RegistrationNumber = "TUV765", Color = "White", Make = "Mercedes-Benz", Model = "Econic" , ArrivalTime = _today + new TimeSpan(10, 00, 00) },
        ];

        // Based on the Pluralsight course (ASP.Net Core 6 Fundamentals)
        public void Initialize(IApplicationBuilder app)
        {
            using GarageContext context = app.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<GarageContext>();

            // This will initialize the database only when empty
            // In the future we might want to include a more explicit reset mechanism
            //if (!context.ParkedVehicle.Any())
            //{
            //    context.AddRange(SeedVehicles);
            //}

            // This will always delete and re-initialize the database
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.AddRange(SeedVehicleTypes);
            context.AddRange(SeedVehicles);

            context.SaveChanges();
        }

    }
}
