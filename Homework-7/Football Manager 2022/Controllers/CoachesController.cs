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
    public class CoachesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoachesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
        {
            var coach = await _unitOfWork.CoachService.GetCoachwithTacticssAsync();
            return Ok(coach);
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coach = await _unitOfWork.CoachService.GetAsync(id);
            return Ok(coach);
        }
        [HttpPost("{id}/add-coach-tactic")]
        public async Task<IActionResult> AddTactic(int id, [FromBody] Tactic tactic)
        {
            tactic.Coaches = (ICollection<Coach>)await _unitOfWork.CoachService.GetAsync(id);
            var createdCoach = await _unitOfWork.TacticService.CreateAsync(tactic);
            return Ok(createdCoach);
        }
        // PUT: api/Coaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            await _unitOfWork.CoachService.UpdateAsync(id, coach);
            return Ok(coach.Id);
        }

        // POST: api/Coaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            var created = await _unitOfWork.CoachService.CreateAsync(coach);
            return Ok(created);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            await _unitOfWork.CoachService.DeleteAsync(id);
            return Ok();
        }

       
    }
}
