using System;
using System.Collections.Generic;

namespace HrApi.Models;

public partial class DocumentDetail
{
    public Guid DocumentId { get; set; }

    public string Description { get; set; } = null!;

    public string Identifier { get; set; } = null!;

    public string Title { get; set; } = null!;

    public Guid EmployeeId { get; set; }

    public virtual EmployeeAdminDetail Employee { get; set; } = null!;
}
