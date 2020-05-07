using System.Threading.Tasks;
using ITDAPi.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITDAPi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItdOrderController:ControllerBase
    {
        private readonly ILogger<ItdOrderController> _logger;

        public ItdOrderController(ILogger<ItdOrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost("saveorder")]
        public async Task<ActionResult>  SaveItdOrder(Model orderjson)
        {
        
           return Ok();
        }


    }
    public class Model{
        public int id { get; set; }
        public string name { get; set; }
    }
}