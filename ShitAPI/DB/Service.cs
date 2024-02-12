using System;
using System.Collections.Generic;

namespace ShitAPI.DB;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public int CodeService { get; set; }

    public string? Deadline { get; set; }

    public string? AverageDeviation { get; set; }
}
