using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication.Services.Abstract;
using WebApplication.Services.Model;

namespace WebApplication.Services.Concrete
{
    public class DataProvider: IDataProvider
    {
        private ControlExpertContext _dbContext;
        public DataProvider() {
            _dbContext = new ControlExpertContext();
        }
        public DbSet<Manufacturer> Manufacturers => _dbContext.Manufacturer;

        public DbSet<VehicleModel> Models => _dbContext.VehicleModel;
    }
}
