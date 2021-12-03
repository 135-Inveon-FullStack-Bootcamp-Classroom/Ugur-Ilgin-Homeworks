using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Football_Manager_2022.Data;
using Football_Manager_2022.Entities;
using Football_Manager_2022.UnitOfWork;
namespace Football_Manager_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalTeamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public NationalTeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/NationalTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalTeam>>> GetNationalTeams()
        {
            var teams = await _unitOfWork.NationalTeamService.GetTeamswithFootballersAsync();
            return Ok(teams);
        }
        [HttpPost("{id}/add-footballer")]

        public async Task<IActionResult> AddFootballer(int id, [FromBody] Footballer footballer)
        {
            footballer.NationalTeam = await _unitOfWork.NationalTeamService.GetAsync(id);
            var createfootballer = await _unitOfWork.FootballerService.CreateAsync(footballer);
            return Ok(createfootballer);
        }
        [HttpPost("{id}/add-manager")]
        public async Task<IActionResult> AddManager(int id, [FromBody] Manager manager)
        {
            manager.Team = await _unitOfWork.NationalTeamService.GetAsync(id);
            var createdmanager = await _unitOfWork.ManagerService.CreateAsync(manager);
            return Ok(createdmanager);
        }
        [HttpPost("{id}/add-coach")]
        public async Task<IActionResult> AddCoach(int id, [FromBody] Coach coach)
        {
            coach.Team = await _unitOfWork.NationalTeamService.GetAsync(id);
            var createdCoach = await _unitOfWork.CoachService.CreateAsync(coach);
            return Ok(createdCoach);
        }
        // GET: api/NationalTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NationalTeam>> GetNationalTeam(int id)
        {
            var team = await _unitOfWork.NationalTeamService.GetAsync(id);
            return Ok(team);
        }

        // PUT: api/NationalTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationalTeam(int id, NationalTeam nationalTeam)
        {
            await _unitOfWork.NationalTeamService.UpdateAsync(id, nationalTeam);
            return Ok(nationalTeam.Id);
        }

        // POST: api/NationalTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NationalTeam>> PostNationalTeam(NationalTeam nationalTeam)
        {
           var created = await _unitOfWork.NationalTeamService.CreateAsync(nationalTeam);
            return Ok(created);
        }

        // DELETE: api/NationalTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationalTeam(int id)
        {
            await _unitOfWork.NationalTeamService.DeleteAsync(id);
            return Ok();
        }

      
    }
}
