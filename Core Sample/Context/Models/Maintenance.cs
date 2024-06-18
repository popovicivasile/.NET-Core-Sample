using System;
using System.Collections.Generic;

namespace Core_Sample.Context.Models;

public partial class Maintenance
{
    public Guid Id { get; set; }

    public double? EngineHours { get; set; }

    public bool? FuelFilter { get; set; }

    public int? EngineOilAmmount { get; set; }

    public int? TransmisionOilAmmount { get; set; }

    public bool? CabAirFilter { get; set; }

    public bool? EngineAirFilter { get; set; }

    public string? Aditional { get; set; }

    public virtual Machine IdNavigation { get; set; } = null!;
}
