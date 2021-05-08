using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ASP_Core_API_3._1_Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        private readonly IConfiguration _config;

        public OperationsController(IConfiguration config)
        {
            _config = config;
        }


        // Using a non resource based verb to ReloadConfig

        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot)_config;
                root.Reload();
                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
