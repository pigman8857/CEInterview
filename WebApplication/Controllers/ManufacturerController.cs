using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Abstract;
using WebApplication.Services.Concrete;
using WebApplication.Services.DTOs;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private IManufacturerService _manufacService;

        public ManufacturerController() {
            _manufacService = new ManufacturerService();
        }

        //todo: Create a method to get manufacturer name by model
        //"api/manufacturer/{modelName}"
        [HttpGet("{modelName}")]
        public ActionResult<string> Get(string modelName)
        { 
            return _manufacService.GetManufacturerByModel(modelName);
        }

        //todo: create a method to return all manufacturers and number of models for these manufacturers
        [HttpGet()]
        public IList<ManufacturerDTO> GetAll()
        {
            return _manufacService.GetAllManufacturers();
        }
    }
}