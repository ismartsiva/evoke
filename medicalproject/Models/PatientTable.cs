using System;
using System.Collections.Generic;

namespace medicalproject.Models;

public partial class PatientTable
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public int? PhoneNo { get; set; }

    public string DoctorType { get; set; } = null!;

    public virtual DoctorTable DoctorTypeNavigation { get; set; } = new DoctorTable();
}
