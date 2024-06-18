using System;
using System.Collections.Generic;

namespace Core_Sample.Context.Models;

public partial class Machine
{
    public Guid AccountId { get; set; }
    public virtual Account Account { get; set; }

    public string MachineSerial { get; set; } = null!;

    public string Trademark { get; set; } = null!;

    public string Model { get; set; } = null!;

    public double? EngineHours { get; set; }

    public string? Name { get; set; }

    public string? FuelType { get; set; }

    public Guid Id { get; set; }

    public virtual Maintenance? Maintenance { get; set; }

    public DateTime CreatedDate { get; set; }
}
