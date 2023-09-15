namespace HrApi.DTOs
{
    public class AddBankDetailDTO
    {
        public string AccountNo { get; set; } = null!;

        public string? AccType { get; set; }

        public string BankName { get; set; } = null!;

        public string? Branch { get; set; }

        public string Ifsc { get; set; } = null!;

        public string? PaymentMode { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
