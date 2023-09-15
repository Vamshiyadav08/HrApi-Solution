using System;
using System.Collections.Generic;

namespace HrApi.Models;

public partial class EmployeeAdminDetail
{
    public Guid EmployeeId { get; set; }

    public string Department { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime DateOfJoin { get; set; }

    public Guid? ReportingManagerId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<BankDetail> BankDetails { get; set; } = new List<BankDetail>();

    public virtual ICollection<DocumentDetail> DocumentDetails { get; set; } = new List<DocumentDetail>();

    public virtual ICollection<EducationDetail> EducationDetails { get; set; } = new List<EducationDetail>();

    public virtual EmployeeCredential? EmployeeCredential { get; set; }

    public virtual ICollection<FamilyDetail> FamilyDetails { get; set; } = new List<FamilyDetail>();

    public virtual ICollection<EmployeeAdminDetail> InverseReportingManager { get; set; } = new List<EmployeeAdminDetail>();

    public virtual ICollection<PersonalDetail> PersonalDetails { get; set; } = new List<PersonalDetail>();

    public virtual EmployeeAdminDetail? ReportingManager { get; set; }
}
