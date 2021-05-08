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
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace ASP_Core_API_3._1_Demo.Controllers
{
    [Route("api/camps/{moniker}/talks")]
    public class TalksController : Controller
    {
        private readonly ICampRepository _repository;
        private readonly ILogger<TalksController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public TalksController(ICampRepository repository,
            ILogger<TalksController> logger,
            IMapper mapper,
            LinkGenerator linkGenerator)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string moniker)
        {
            try
            {
                var talks = await _repository.GetTalksByMonikerAsync(moniker);
                return Ok(_mapper.Map<IEnumerable<Talk>, IEnumerable<TalkModel>>(talks));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
            }
            return BadRequest("Failed To Get Camp");
}
    }
}
