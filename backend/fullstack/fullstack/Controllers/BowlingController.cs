using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private BowlingLeagueContext _BowlingLeagueContext;

        public BowlingController(BowlingLeagueContext temp)
        {
            _BowlingLeagueContext = temp;
        }

        [HttpGet(Name = "GetBowler")]
        public IEnumerable<string> Get()
        {
            var bowlerLastNames = _BowlingLeagueContext.Bowlers
                .Select(b => b.BowlerLastName)
                .ToList();

            return bowlerLastNames;
        }
    }
}
