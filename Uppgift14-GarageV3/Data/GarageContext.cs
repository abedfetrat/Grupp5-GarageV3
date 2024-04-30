using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uppgift14_GarageV3.Models;

namespace Uppgift14_GarageV3.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext (DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        public DbSet<Uppgift14_GarageV3.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;
    }
}
