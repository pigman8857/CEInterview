using System.Collections.Generic;
using WebApplication.Services.DTOs;

namespace WebApplication.Services.Abstract
{
    public interface IManufacturerService
    {
        string GetManufacturerByModel(string model);

        IList<ManufacturerDTO> GetAllManufacturers();
    }
}
