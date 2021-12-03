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
    public class ManagementPositionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManagementPositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/ManagementPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementPosition>>> GetManagementPositions()
        {
            var managementPositions = await _unitOfWork.ManagementPositionService.GetAllAsync();
            return Ok(managementPositions);
        }

        // GET: api/ManagementPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagementPosition>> GetManagementPosition(int id)
        {
            var managementPosition = await _unitOfWork.ManagementPositionService.GetAsync(id);
            return Ok(managementPosition);
        }

        // PUT: api/ManagementPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagementPosition(int id, ManagementPosition managementPosition)
        {
            await _unitOfWork.ManagementPositionService.UpdateAsync(id, managementPosition);
            return Ok(managementPosition.Id);
        }

        // POST: api/ManagementPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagementPosition>> PostManagementPosition(ManagementPosition managementPosition)
        {
            var created = await _unitOfWork.ManagementPositionService.CreateAsync(managementPosition);
            return Ok(created);
        }

        // DELETE: api/ManagementPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagementPosition(int id)
        {
            await _unitOfWork.ManagementPositionService.DeleteAsync(id);
            return Ok();
        }

     
    }
}
