using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Services.DTOs;
using WebApplication.Services;
using System.Linq;

namespace WebApplication.Services.Tests
{
    public static class ManufacturerTestHelper
    {
        
        public static IList<ManufacturerDTO> MakeTestModels()
        {
            IList<ManufacturerDTO> list = new List<ManufacturerDTO>(71);

            var manufacturers = Db.GetManufacturers();
            var vehicleModels = Db.GetModels();
            manufacturers.ForEach((manufacturer) => {
                int modelCount = vehicleModels.Where((vehicleModel) =>
                {
                    return vehicleModel.ManufacturerId == manufacturer.Id;
                }).Count();

                list.Add(new ManufacturerDTO(manufacturer, modelCount));
            });


            return list;
        }
    }
}
