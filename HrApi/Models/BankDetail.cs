using System;
using System.Collections.Generic;

namespace HrApi.Models;

public partial class BankDetail
{
    public Guid BankDetailsId { get; set; }

    public string AccountNo { get; set; } = null!;

    public string? AccType { get; set; }

    public string BankName { get; set; } = null!;

    public string? Branch { get; set; }

    public string Ifsc { get; set; } = null!;

    public string? PaymentMode { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual EmployeeAdminDetail Employee { get; set; } = null!;
}
