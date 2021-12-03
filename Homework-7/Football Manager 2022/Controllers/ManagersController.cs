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
    public class ManagersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManagersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            var manager = await _unitOfWork.ManagerService.GetAllAsync();
            return Ok(manager);
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _unitOfWork.ManagerService.GetAsync(id);
            return Ok(manager);
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, Manager manager)
        {
            await _unitOfWork.ManagerService.UpdateAsync(id, manager);
            return Ok(manager.Id);
        }

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
            var created = await _unitOfWork.ManagerService.CreateAsync(manager);
            return Ok(created);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            await _unitOfWork.ManagerService.DeleteAsync(id);
            return Ok();
        }

        
    }
}
