using System.Collections.Generic;
using System.Linq;
using Mastermind.Core;
using Microsoft.AspNetCore.Mvc;

namespace Mastermind.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MastermindController : ControllerBase
    {
        [HttpPost]
        [Route("reset")]
        public StatusCodeResult Get()
        {
            MastermindState.Engine = new MastermindEngine();
            return Ok();
        }

        /*[HttpPost]
        public MastermindResponse Post([FromBody]IEnumerable<AttemptColor> attempt)
        {
            MastermindState.Engine ??= new MastermindEngine();
            MastermindState.Engine.SaveAttempt(attempt.ToArray());
            MastermindState.Engine.CalculateHints();
            return new MastermindResponse
            {
                Rows = MastermindState.Engine.Attempts,
                Win = MastermindState.Engine.Validate()
            };
        }
        
        [HttpGet]
        public MastermindResponse GetState()
        {
            MastermindState.Engine ??= new MastermindEngine();
            return new MastermindResponse
            {
                Rows = MastermindState.Engine.Attempts,
                Win = MastermindState.Engine.Validate()
            };
        }*/
    }
}