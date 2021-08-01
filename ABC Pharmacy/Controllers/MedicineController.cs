using ABC_Pharmacy.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Pharmacy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        //private static List<Medicine> medicines = new List<Medicine> { 
        //new Medicine(){MedicineName = "Paracetamol 650mg" , BrandName = "ALBIMOL-650 tab", ExpiryDate = new DateTime(2021,10,20), Quantity = 100, Price = 20, Notes = "fever"},
        //new Medicine(){MedicineName = "Paracetamol 80mg" , BrandName = "PARACETANAL", ExpiryDate = new DateTime(2021,08,20), Quantity = 90, Price = 15, Notes = "fever"},
        //new Medicine(){MedicineName = "Aspirin" , BrandName = "Bayer", ExpiryDate = new DateTime(2021,11,20), Quantity = 8, Price = 20, Notes = "Headache"},
        //new Medicine(){MedicineName = "Fenoprofen" , BrandName = "Nalfon", ExpiryDate = new DateTime(2021,12,20), Quantity = 60, Price = 30, Notes = "Headache"},
        //new Medicine(){MedicineName = "Pseudoephedrine" , BrandName = "Actifed", ExpiryDate = new DateTime(2021,10,10), Quantity = 40, Price = 10, Notes = "Cold"},
        //new Medicine(){MedicineName = "Dextromethorphan" , BrandName = "Benylin Dry Cough", ExpiryDate = new DateTime(2022,01,20), Quantity = 90, Price = 25, Notes = "Cold"},
        //};

        private readonly Settings _settings;

        public MedicineController(Settings settings)
        {
            _settings = settings;
        }

        [HttpGet("GetMedicine")]
        public List<Medicine> GetMedicine()
        {
            string filepath = _settings.FilePath;
            List<Medicine> medicines = JsonConvert.DeserializeObject<List<Medicine>>(System.IO.File.ReadAllText(@filepath));
            return medicines;
        }

        [HttpPost("AddMedicine")]
        public List<Medicine> AddMedicine(Medicine medicine)
        {

            string filepath = _settings.FilePath;                                  
            List<Medicine> medicines = JsonConvert.DeserializeObject<List<Medicine>>(System.IO.File.ReadAllText(@filepath));
            medicines.Add(medicine);
            var insertData = JsonConvert.SerializeObject(medicines);
            System.IO.File.WriteAllText(@filepath, insertData);
            return medicines;
        }

    }
}
