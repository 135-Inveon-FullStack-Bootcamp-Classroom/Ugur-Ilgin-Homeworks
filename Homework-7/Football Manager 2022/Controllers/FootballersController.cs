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
    public class FootballersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FootballersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Footballers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            var footballers = await _unitOfWork.FootballerService.GetFootballerwithPosition();
            return Ok(footballers);
        }
        [HttpPost("{id}/add-footballer-positions")]
        public async Task<IActionResult> AddPositions(int id, [FromBody] Positions positions)
        {
            positions.Footballers = (ICollection<Footballer>)await _unitOfWork.FootballerService.GetAsync(id);
            var createdPositions = await _unitOfWork.PositionService.CreateAsync(positions);
            return Ok(createdPositions);
        }
        // GET: api/Footballers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> GetFootballer(int id)
        {
            var footballer = await _unitOfWork.FootballerService.GetAsync(id);
            return Ok(footballer);
        }

        // PUT: api/Footballers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootballer(int id, Footballer footballer)
        {
            await _unitOfWork.FootballerService.UpdateAsync(id, footballer);
            return Ok(footballer.Id);
        }

        // POST: api/Footballers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Footballer>> PostFootballer(Footballer footballer)
        {
            var created = await _unitOfWork.FootballerService.CreateAsync(footballer);
            return Ok(created);
        }

        // DELETE: api/Footballers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballer(int id)
        {
            await _unitOfWork.FootballerService.DeleteAsync(id);
            return Ok();
        }

       
    }
}
