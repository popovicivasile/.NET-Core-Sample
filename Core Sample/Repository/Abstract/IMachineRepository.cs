using Core_Sample.Context.Models;


namespace Core_Sample.Repository.Abstract
{
    public interface IMachineRepository
    {
        Task CreateMachine(Machine machine);
        Task<Machine> GetMachineAsync(Guid id);

        Task<List<Machine>> GetAllMachinesAsync(Guid AccountID);

        Task UpdateMachine(Machine machine);

        Task DeleteMachine(Guid id);

    }
}
