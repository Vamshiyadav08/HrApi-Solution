namespace HrApi.DTOs
{
    public class AddEducationDetailDTO
    {
        public string College { get; set; } = null!;

        public string Gpa { get; set; } = null!;

        public string Specialization { get; set; } = null!;

        public string University { get; set; } = null!;

        public DateTime Year { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
