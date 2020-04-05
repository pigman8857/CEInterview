using System;
using System.Collections.Generic;

namespace WebApplication.Services.Model
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            VehicleModel = new HashSet<VehicleModel>();
        }

        public string Id { get; set; }
        public string ManufacturerName { get; set; }

        public ICollection<VehicleModel> VehicleModel { get; set; }
    }
}
