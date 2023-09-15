

namespace HrApi.Models;

public partial class EmployeeCredential
{
    public Guid EmployeeId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual EmployeeAdminDetail Employee { get; set; } = null!;
}
