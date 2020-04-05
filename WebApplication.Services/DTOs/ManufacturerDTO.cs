using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Services.Model;

namespace WebApplication.Services.DTOs
{
    public class ManufacturerDTO
    {
        
        private Manufacturer _manufacturer;
        public string ManufacturerName
        {
            get {
                return _manufacturer.ManufacturerName;
            } 
        }

        private int _numberOfModels;
        public int NumberOfModels
        {
            get
            {
                return _numberOfModels;
            }
        }

        public ManufacturerDTO(Manufacturer manufacturer, int numberOfModels) {
            _manufacturer = manufacturer;
            _numberOfModels = numberOfModels;
        }
        
    }
}
