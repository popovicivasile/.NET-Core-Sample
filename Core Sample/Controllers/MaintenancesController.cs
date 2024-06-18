using Core_Sample.Context.Models;
using Core_Sample.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace Core_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenancesController(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetMaintenances(Guid Id)
        {
            return await _maintenanceRepository.GetMaintenancesAsync(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Maintenance>> PostMaintenance(Maintenance maintenance)
        {

            try
            {
                await _maintenanceRepository.CreateMaintenance(maintenance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return CreatedAtAction("GetMaintenance", new { id = maintenance.Id }, maintenance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenance(Guid id)
        {
            await _maintenanceRepository.DeleteMaintenanceAsync(id);

            return NoContent();
        }


    }
}
