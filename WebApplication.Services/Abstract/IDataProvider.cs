using System.Collections.Generic;
using WebApplication.Services.Model;
using Microsoft.EntityFrameworkCore;
namespace WebApplication.Services.Abstract
{
    public interface IDataProvider
    {
        DbSet<Manufacturer> Manufacturers { get; }
        DbSet<VehicleModel> Models { get; }
    }
}