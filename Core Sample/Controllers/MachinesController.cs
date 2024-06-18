using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core_Sample.Context;
using Core_Sample.Context.Models;
using Core_Sample.Repository.Abstract;

namespace Core_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly IMachineRepository _machineRepository;

        public MachinesController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachines(Guid AccountId)
        {
            return await _machineRepository.GetAllMachinesAsync(AccountId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Machine>> GetMachine(Guid id)
        {
            var machine = await _machineRepository.GetMachineAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return machine;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(Guid id, Machine machine)
        {
            

            try
            {
                await _machineRepository.UpdateMachine(machine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine(Machine machine)
        {
            
            try
            {
                await _machineRepository.CreateMachine(machine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
  
            }

            return CreatedAtAction("GetMachine", new { id = machine.Id }, machine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(Guid id)
        {
            var machine = _machineRepository.DeleteMachine(id);

            if (machine == null)
            {
                return NotFound();
            }
 
            return Ok("Machine Deleted");
        }

    }
}
