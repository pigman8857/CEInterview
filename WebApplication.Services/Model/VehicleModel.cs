using System;
using System.Collections.Generic;

namespace WebApplication.Services.Model
{
    public partial class VehicleModel
    {
        public string Id { get; set; }
        public string ModelName { get; set; }
        public string ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
