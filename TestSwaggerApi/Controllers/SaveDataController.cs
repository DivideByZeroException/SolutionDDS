using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestSwaggerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaveDataController : ControllerBase
    {

        
        private readonly ILogger<SaveDataController> _logger;

        public SaveDataController(ILogger<SaveDataController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public void Post(string type,
        int summ,
        string fond,
        string what,
        string person,
        string month,
        string month_number,
        DateTime date,
        string comm)
        {
            SaveData savedata = new SaveData(type, summ, fond, what,
             person, month, month_number, date, comm);
            Console.WriteLine();
            //SaveData saveData = new SaveData()
            Console.WriteLine("Сработает СэйвКонтролер");

            
        }

    }
}
