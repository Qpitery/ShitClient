using System;
using System.Collections.Generic;

namespace ShitAPI.DB;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int CodeService { get; set; }

    public string Status { get; set; } = null!;
}
