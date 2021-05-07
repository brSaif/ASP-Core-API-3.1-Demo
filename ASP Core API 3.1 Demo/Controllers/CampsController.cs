using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_Core_API_3._1_Demo.Data;
using ASP_Core_API_3._1_Demo.Data.Entities;
using ASP_Core_API_3._1_Demo.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_Core_API_3._1_Demo.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        private readonly ICampRepository _repository;
        private readonly ILogger<CampsController> _logger;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository,
            ILogger<CampsController> logger,
            IMapper mapper
            )
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCamps(bool includeTalks = false)
        {
            try
            {
                var results = await  _repository.GetAllCampsAsync(includeTalks);

                if (results == null) return NotFound();

                return Ok(_mapper.Map<IEnumerable<Camp>,IEnumerable<CampModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
                return BadRequest("Failed To Load Data");

            }

        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> Get(string moniker)
        {
            try
            {
                Camp Camp = await _repository.GetCampAsync(moniker);

                if (Camp == null) return NotFound();

                return Ok(_mapper.Map<CampModel>(Camp));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
                return BadRequest("Failed To Load Data");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult> SearchByDate(DateTime theDate, bool includeTalks = false)
        {
            try
            {
                var result = await _repository.GetAllCampsByEventDate(theDate, includeTalks);
               
                if (!result.Any()) return NotFound();

                return Ok(_mapper.Map<IEnumerable<CampModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
                return BadRequest("Failed To Load Data");
            }
        }
    }
}
