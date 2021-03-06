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

            return BadRequest("Failed To Get Talks by moniker");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(string moniker, int id)
        {
            try
            {
                var talks = await _repository.GetTalkByMonikerAsync(moniker, id);
                if (talks == null) return NotFound();
                
                return Ok(_mapper.Map<TalkModel>(talks));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
            }

            return BadRequest("Failed To Get the talk by Talk Id");
        }

        [HttpPost]
        public async Task<ActionResult> Post(string moniker, [FromBody] TalkModel model)
        {
            try
            {
                var camp = await _repository.GetCampAsync(moniker);
                if (camp == null) return NotFound("Camp Does Not Exist");

                var talk = _mapper.Map<Talk>(model);
                talk.Camp = camp;

                if (model.Speaker == null) return BadRequest("Speaker ID is required");
                var speaker = await _repository.GetSpeakerAsync(model.Speaker.SpeakerId);
                if (speaker == null) return BadRequest("Speaker not found");

                talk.Speaker = speaker;

                _repository.Add(talk);

                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values: new {moniker, id = talk.TalkId});
                    return Created(location, _mapper.Map<TalkModel>(talk));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
            }

            return BadRequest("Failed To save new talk");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TalkModel>> Put(string moniker, int id, [FromBody]TalkModel model)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker,id,true);
                if (talk == null) return NotFound("Talk Does not exist");

                _mapper.Map(model, talk);

                // After the Mapping
                if (model.Speaker != null)
                {
                    var speaker = await _repository.GetSpeakerAsync(model.Speaker.SpeakerId);
                    if (speaker != null)
                    {
                        talk.Speaker = speaker;
                    }
                }

               

                if (await _repository.SaveChangesAsync()) return _mapper.Map<TalkModel>(talk);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
            }
            return BadRequest("Failed To get the Talk to update");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string moniker, int id)
        {
            try
            {
                var talk = await _repository.GetTalkByMonikerAsync(moniker, id);
                if (talk == null) return NotFound("Failed to find the talk to delete");

                _repository.Delete(talk);
                if(await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed To Load Data. The following exception is thrown {ex}");
            }
            return BadRequest("Failed To delete talk ");
        }
    }
}
