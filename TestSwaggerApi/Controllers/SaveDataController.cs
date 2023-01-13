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
        public void PostFromCLient(DDSDataRow data)
        {
            
            WorkWithExcel workWithExcel = new WorkWithExcel();
            workWithExcel.Save(data.Type, data.Sum, data.Fond, data.What,
             data.Person, data.Month, data.NumberMonth, data.Date, data.Comm);
        }
    }
}
