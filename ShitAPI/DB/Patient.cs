using System;
using System.Collections.Generic;

namespace ShitAPI.DB;

public partial class Patient
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateTime DoB { get; set; }

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberInsurance { get; set; } = null!;

    public string TypeInsurance { get; set; } = null!;

    public int InsuranceCompanyId { get; set; }

    public string Country { get; set; } = null!;

    public string Ein { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public virtual InsuranceCompany InsuranceCompany { get; set; } = null!;
}
