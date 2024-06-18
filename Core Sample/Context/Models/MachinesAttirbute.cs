using System;
using System.Collections.Generic;

namespace Core_Sample.Context.Models;

public partial class MachinesAttirbute
{
    public int Id { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public double? Timestamp { get; set; }

    public double? Speed { get; set; }

    public long? Imei { get; set; }
}
