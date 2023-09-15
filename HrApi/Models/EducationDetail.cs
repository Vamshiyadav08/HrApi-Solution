using System;
using System.Collections.Generic;

namespace HrApi.Models;

public partial class EducationDetail
{
    public Guid EducationId { get; set; }

    public string College { get; set; } = null!;

    public string Gpa { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string University { get; set; } = null!;

    public DateTime Year { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual EmployeeAdminDetail Employee { get; set; } = null!;
}
