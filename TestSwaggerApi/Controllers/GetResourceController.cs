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
    public class GetResourceController : ControllerBase
    {
       

        private readonly ILogger<GetResourceController> _logger;

        public GetResourceController(ILogger<GetResourceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<IList<object>> Get()
        {
            GetResource getResource = new GetResource();
            return getResource.Val;
        }
    }
}
