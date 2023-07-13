using System;
using System.Collections.Generic;

namespace medicalproject.Models;

public partial class DoctorTable
{
    public string DoctorType { get; set; } = null!;

    public string? TypeOfMedicines { get; set; }

    public virtual ICollection<PatientTable> PatientTables { get; set; } = new List<PatientTable>();
}
