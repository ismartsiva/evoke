using System;
using System.Collections.Generic;

namespace medicalproject.Models;

public partial class Parma
{
    public int? AppointmentId { get; set; }

    public string? Status { get; set; }

    public string? Agegroup { get; set; }

    public virtual PatientTable? Appointment { get; set; }
}
