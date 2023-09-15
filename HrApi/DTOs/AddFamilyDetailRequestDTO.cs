namespace HrApi.DTOs
{
    public class AddFamilyDetailRequestDTO
    {
        public string Address { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public string? Occupation { get; set; }

        public string? Relationship { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
