using System;
using System.Collections.Generic;

namespace ShitAPI.DB;

public partial class InsuranceCompany
{
    public int Id { get; set; }

    public string InsuranceName { get; set; } = null!;

    public string InsuranceAddress { get; set; } = null!;

    public string InsuranceInn { get; set; } = null!;

    public string InsurancePc { get; set; } = null!;

    public string InsuranceBik { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
