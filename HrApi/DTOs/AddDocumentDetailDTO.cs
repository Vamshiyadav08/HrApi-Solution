namespace HrApi.DTOs
{
    public class AddDocumentDetailDTO
    {
        public string Description { get; set; } = null!;

        public string Identifier { get; set; } = null!;

        public string Title { get; set; } = null!;

        public Guid EmployeeId { get; set; }
    }
}
