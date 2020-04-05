using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WebApplication.Services.Abstract;
using WebApplication.Services.Concrete;
using WebApplication.Services.DTOs;

namespace WebApplication.Services.Tests
{
    [TestFixture]
    public class ManufacturerServiceTests
    {

        private IManufacturerService _manufacturerService;

        public ManufacturerServiceTests()
        {
            
        }

        [SetUp]
        public void Setup()
        {
            _manufacturerService = new ManufacturerService();
        }
        //todo: fix test
        [TestCase("488GTB", "FERRARI")]
        [TestCase("A8ハイブリッド", "AUDI")]
        [TestCase("エテルナ", "MITSUBISHI")]
        [TestCase("スプリンタートレノ", "TOYOTA")]
        [TestCase("パサートGTEヴァリアント", "VOLKSWAGEN")]
        public void CanIdentifyManufacturer(string value, string expected)
        {
            var result = _manufacturerService.GetManufacturerByModel(value);
            Assert.AreEqual(result, expected);
        }

        
        [Test]
        public void GetAllManufacturer() {
            var testModels = (List<ManufacturerDTO>)(ManufacturerTestHelper.MakeTestModels());
            var result = (_manufacturerService.GetAllManufacturers());
   
                for (int i = 0, max = testModels.Count; i < max; i++)
                {
                    var testModel = testModels[i];

                    var query = result.Where((dto) =>
                    {
                        return dto.ManufacturerName == testModel.ManufacturerName;
                    }).Single();

                    Assert.AreNotEqual(null, query);
                    Assert.AreEqual(testModel.NumberOfModels, query.NumberOfModels);

                }
  

        }
        

    }
}
