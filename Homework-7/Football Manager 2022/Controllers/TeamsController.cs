using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Football_Manager_2022.Data;
using Football_Manager_2022.Entities;
using Football_Manager_2022.ServiceImplementetions;
using Football_Manager_2022.ServiceAbstracts;
using Football_Manager_2022.UnitOfWork;

namespace Football_Manager_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public TeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams= await _unitOfWork.TeamService.GetAllValuesAsync();
            return Ok(teams);
        }
        [HttpPost("{id}/add-footballer")]

        public async Task<IActionResult> AddFootballer(int id , [FromBody] Footballer footballer)
        {
            footballer.Team = await _unitOfWork.TeamService.GetAsync(id);
          var createfootballer= await _unitOfWork.FootballerService.CreateAsync(footballer);
            return Ok(createfootballer);
        }
        [HttpPost("{id}/add-manager")]
        public async Task<IActionResult> AddManager(int id, [FromBody] Manager manager)
        {
            manager.Team = await _unitOfWork.TeamService.GetAsync(id);
            var createdmanager = await _unitOfWork.ManagerService.CreateAsync(manager);
            return Ok(createdmanager);
        }
        [HttpPost("{id}/add-coach")]
        public async Task<IActionResult> AddCoach(int id, [FromBody] Coach coach)
        {
            coach.Team = await _unitOfWork.TeamService.GetAsync(id);
            var createdCoach = await _unitOfWork.CoachService.CreateAsync(coach);
            return Ok(createdCoach);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _unitOfWork.TeamService.GetAsync(id) ;
            return Ok(team);
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            await _unitOfWork.TeamService.UpdateAsync(id, team);
            return Ok(team.Id);
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
           var created= await _unitOfWork.TeamService.CreateAsync(team);
            return Ok(created);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            
            await _unitOfWork.TeamService.DeleteAsync(id); 
            return Ok();
        }

       
    }
}
