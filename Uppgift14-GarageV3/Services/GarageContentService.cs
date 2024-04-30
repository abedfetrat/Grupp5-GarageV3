using Microsoft.EntityFrameworkCore;
using Uppgift14_GarageV3.Data;

namespace Uppgift14_GarageV3.Services
{
    public class GarageContentService : IGarageContentService
    {
        private readonly GarageContext _context;
        public const int GarageMaxSpaces = 10;

        public GarageContentService(GarageContext context)
        {
            _context = context;
        }

        public async Task<int> NoOfSpacesAvailable()
        {
            var noOfParkedVehicles = await _context.ParkedVehicle.CountAsync();
            return GarageMaxSpaces - noOfParkedVehicles;
        }
    }
}
