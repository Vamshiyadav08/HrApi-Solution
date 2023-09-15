
using HrApi.Models;
namespace HrApi.Repositories.Interface
{
    public interface IHrApiRepositary
    {   //FAM ED BANK DOCUMENT PERSONAL
        public Task<EmployeeCredential?> AddCredentialAsync(EmployeeCredential employeeCredential);    
        public Task<FamilyDetail?> AddFamilyAsync(FamilyDetail familyDetail);    
        public Task<EducationDetail?> AddEducationAsync(EducationDetail educationDetail);    
        public Task<BankDetail?> AddBankAsync(BankDetail bankDetail);    
        public Task<DocumentDetail?> AddDocumentAsync(DocumentDetail documentDetail);    
        public Task<PersonalDetail?> AddPersonalAsync(PersonalDetail personalDetail);    

        public Task<EmployeeCredential?> GetCredentialAsync(string email);    
        public Task<EmployeeCredential?> GetCredentialByIdAsync(Guid employeeId);

        public Task<List<FamilyDetail>?> GetFamilyDetailsByIdAsync(Guid employeeId);
        public Task<List<EducationDetail>?> GetEducationDetailsByIdAsync(Guid employeeId);
        public Task<List<BankDetail>?> GetBankDetailsByIdAsync(Guid employeeId);
        public Task<List<DocumentDetail>?> GetDocumentDetailsByIdAsync(Guid employeeId);
        public Task<List<PersonalDetail>?> GetPersonalDetailsByIdAsync(Guid employeeId);
        

        public Task<EmployeeAdminDetail?> GetEmployeeAdminDetailAsync(Guid employeeId);    
        public Task<EmployeeCredential?> UpdatePassword(Guid employeeId,string resetPassword);    
    }
}
