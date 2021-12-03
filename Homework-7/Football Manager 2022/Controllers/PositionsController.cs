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
    public class PositionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Positions>>> GetPositions()
        {
            var positions = await _unitOfWork.PositionService.GetAllAsync();
            return Ok(positions);
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Positions>> GetPositions(int id)
        {
            var positions = await _unitOfWork.PositionService.GetAsync(id);
            return Ok(positions);
        }

        // PUT: api/Positions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositions(int id, Positions positions)
        {
            await _unitOfWork.PositionService.UpdateAsync(id, positions);
            return Ok(positions.Id);
        }

        // POST: api/Positions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Positions>> PostPositions(Positions positions)
        {
            var created = await _unitOfWork.PositionService.CreateAsync(positions);
            return Ok(created);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositions(int id)
        {
            await _unitOfWork.PositionService.DeleteAsync(id);
            return Ok();
        }

       
    }
}
