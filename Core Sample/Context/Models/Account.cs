namespace Core_Sample.Context.Models
{
    public class Account
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public int maxMachines { get; set; }

        public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();


    }
}
