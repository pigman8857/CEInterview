using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using WebApplication.Services.Abstract;
using WebApplication.Services.DTOs;

namespace WebApplication.Services.Concrete
{
    public class ManufacturerService : IManufacturerService
    {
        private IDataProvider _dataProvider;

        public ManufacturerService()//IDataProvider dataProvider)
        {
            _dataProvider = new DataProvider() ;
        }
        public string GetManufacturerByModel(string modelName)
        {

            var manufacturerId = _dataProvider.Models.AsEnumerable().Where((model) =>
            {
                return model.ModelName == modelName;
            }).Select((model) => { 
                return model.ManufacturerId; 
            }).Single();
            
            var manufacturerName = _dataProvider.Manufacturers.AsEnumerable().Where((manufacturer) => {
                return manufacturer.Id == manufacturerId;
            }).Select((manufacturer) => {
                return manufacturer.ManufacturerName;
            }).Single();

            return manufacturerName;
        }

        public IList<ManufacturerDTO> GetAllManufacturers() {
            var manufacturers = _dataProvider.Manufacturers.AsEnumerable();
            var models = _dataProvider.Models.AsEnumerable();
            
            var manufacturerCount = manufacturers.Count();

            IList<ManufacturerDTO> result = new List<ManufacturerDTO>(manufacturerCount);
            foreach (var manufacturer in manufacturers)
            {
                var modelCount = models.Where((model) =>
                {
                    return model.ManufacturerId == manufacturer.Id;
                }).Count();

                result.Add(new ManufacturerDTO(manufacturer, modelCount));

            }

            return result;
        }
    }
}