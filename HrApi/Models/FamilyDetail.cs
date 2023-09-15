using System;
using System.Collections.Generic;

namespace HrApi.Models;

public partial class FamilyDetail
{
    public Guid FamilyId { get; set; }

    public string Address { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? Occupation { get; set; }

    public string? Relationship { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual EmployeeAdminDetail Employee { get; set; } = null!;
}
