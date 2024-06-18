using Core_Sample.Context;
using Core_Sample.Repository.Abstract;
using Core_Sample.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Sample.Repository.Real
{
    public class MachineRepository : IMachineRepository
    {
        private readonly ServiceContext _context;

        public MachineRepository(ServiceContext context)
        {
            _context = context;
        }


        public async Task CreateMachine(Machine machine)
        {
            Machine machines = new Machine
            {
                Id = Guid.NewGuid(),
                Name = machine.Name,
                CreatedDate = DateTime.Now,
                AccountId = machine.AccountId
            };

            _context.Machines.Add(machines);
            await _context.SaveChangesAsync();
        }

        public async Task<Machine> GetMachineAsync(Guid id)
        {
            var machine = await _context.Machines.Where(m => m.Id == id).FirstOrDefaultAsync();
            return machine;
        }



        public async Task<List<Machine>> GetAllMachinesAsync(Guid AccountID)
        {
            return await _context.Machines.Where(m => m.AccountId == AccountID).ToListAsync();
        }


        public async Task UpdateMachine(Machine machine)
        {
            _context.Update(machine);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteMachine(Guid id)
        {
            var machine = await _context.Machines.FindAsync(id);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
        }
    }
}
