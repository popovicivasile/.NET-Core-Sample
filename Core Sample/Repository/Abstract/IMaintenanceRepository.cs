using Core_Sample.Context.Models;

namespace Core_Sample.Repository.Abstract
{
    public interface IMaintenanceRepository
    {
        Task CreateMaintenance(Maintenance maintenance);
        Task<List<Maintenance>> GetMaintenancesAsync(Guid MachineID);
        Task DeleteMaintenanceAsync(Guid id);
    }
}
