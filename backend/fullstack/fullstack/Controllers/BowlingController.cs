using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using fullstack;

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
        public IEnumerable<BowlerDto> Get()
        {
            var allowedTeams = new List<string> { "Marlins", "Sharks" };

            var bowlers = _BowlingLeagueContext.Bowlers
                .Include(b => b.Team)
                .Where (b => allowedTeams.Contains(b.Team.TeamName))
                .Select(b => new BowlerDto
                {
                    BowlerId = b.BowlerId,
                    FirstName = b.BowlerFirstName,
                    LastName = b.BowlerLastName,
                    MiddleName = b.BowlerMiddleInit,
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    PhoneNumber = b.BowlerPhoneNumber,
                    TeamName = b.Team.TeamName
                })
                .ToList();

            return bowlers;
        }
    }
}
