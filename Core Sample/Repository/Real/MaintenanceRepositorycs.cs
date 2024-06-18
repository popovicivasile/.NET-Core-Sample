using Core_Sample.Repository.Abstract;
using Core_Sample.Context;
using Core_Sample.Context.Models;
using Microsoft.EntityFrameworkCore;
namespace Core_Sample.Repository.Real
{
    public class MaintenanceRepositorycs : IMaintenanceRepository
    {

        private readonly ServiceContext _context;
        public MaintenanceRepositorycs(ServiceContext context)
        {
            _context = context;
        }

        public async Task CreateMaintenance(Maintenance maintenance)
        {
            Maintenance maint = new Maintenance
            {
                Id = Guid.NewGuid(),
                EngineHours = maintenance.EngineHours,
                FuelFilter = maintenance.FuelFilter,
                EngineOilAmmount = maintenance.EngineOilAmmount,
                TransmisionOilAmmount = maintenance.TransmisionOilAmmount,
                CabAirFilter = maintenance.CabAirFilter,
                EngineAirFilter = maintenance.EngineAirFilter
            };

            _context.Maintenances.Add(maint);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Maintenance>> GetMaintenancesAsync(Guid MachineID)
        {
            return await _context.Maintenances.Where(m => m.Id == MachineID).ToListAsync();
        }


        public async Task DeleteMaintenanceAsync (Guid id)
        {
            var maintenance = await _context.Maintenances.FindAsync(id);
            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();
        }


    }
}
