using System;
using System.Collections.Generic;

namespace HrApi.Models;

public partial class PersonalDetail
{
    public Guid EmpPersonalId { get; set; }

    public string Address { get; set; } = null!;

    public string? BloodGroup { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string FirstName { get; set; } = null!;

    public string? Gender { get; set; }

    public string LastName { get; set; } = null!;

    public string Linkedin { get; set; } = null!;

    public string MartialStatus { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string PersonalEmail { get; set; } = null!;

    public string? Religion { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual EmployeeAdminDetail Employee { get; set; } = null!;
}
