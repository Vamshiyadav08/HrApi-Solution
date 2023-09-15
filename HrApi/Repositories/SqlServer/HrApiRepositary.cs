using HrApi.DTOs;
using HrApi.Models;
using HrApi.Repositories.Interface;


namespace HrApi.Repositories.SqlServer
{
    public class HrApiRepositary:IHrApiRepositary
    {
        private readonly HrStopssContext _dbContext;

        public HrApiRepositary(HrStopssContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeCredential?> AddCredentialAsync(EmployeeCredential employeeCredential)
        {
            employeeCredential.EmployeeId = Guid.NewGuid();
            await _dbContext.EmployeeCredentials.AddAsync(employeeCredential);
            await _dbContext.SaveChangesAsync();
            return employeeCredential;
        }
        public async Task<FamilyDetail?> AddFamilyAsync(FamilyDetail familyDetail)
        {
            familyDetail.FamilyId = Guid.NewGuid();
            await _dbContext.FamilyDetails.AddAsync(familyDetail);
            await _dbContext.SaveChangesAsync();
            return familyDetail;
        }
        public async Task<EducationDetail?> AddEducationAsync(EducationDetail educationDetail)
        {
            educationDetail.EmployeeId = Guid.NewGuid();
            await _dbContext.EducationDetails.AddAsync(educationDetail);
            await _dbContext.SaveChangesAsync();
            return educationDetail;
        }
        public async Task<BankDetail?> AddBankAsync(BankDetail bankDetail)
        {
            bankDetail.EmployeeId = Guid.NewGuid();
            await _dbContext.BankDetails.AddAsync(bankDetail);
            await _dbContext.SaveChangesAsync();
            return bankDetail;
        }
        public async  Task<DocumentDetail?> AddDocumentAsync(DocumentDetail documentDetail)
        {
            documentDetail.EmployeeId = Guid.NewGuid();
            await _dbContext.DocumentDetails.AddAsync(documentDetail);
            await _dbContext.SaveChangesAsync();
            return documentDetail;
        }
        public async Task<PersonalDetail?> AddPersonalAsync(PersonalDetail personalDetail)
        {
            personalDetail.EmployeeId = Guid.NewGuid();
            await _dbContext.PersonalDetails.AddAsync(personalDetail);
            await _dbContext.SaveChangesAsync();
            return personalDetail;

        }
        public async Task<EmployeeCredential?> GetCredentialAsync(string email)
        {
          return await _dbContext.EmployeeCredentials.Include(x=>x.Employee).FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<EmployeeAdminDetail?> GetEmployeeAdminDetailAsync(Guid employeeId)
        {
            return await _dbContext.EmployeeAdminDetails.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<EmployeeCredential?> GetCredentialByIdAsync(Guid employeeId)
        {
            
            return await _dbContext.EmployeeCredentials.Include(x => x.Employee).FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }
        public async Task<List<FamilyDetail>?> GetFamilyDetailsByIdAsync(Guid employeeId)
        {
            return await _dbContext.FamilyDetails.Include(x => x.Employee).Where(x => x.EmployeeId == employeeId).Include(x=>x.Employee).ToListAsync();

        }
        public async Task<List<EducationDetail>?> GetEducationDetailsByIdAsync(Guid employeeId)
        {
            return await _dbContext.EducationDetails.Include(x => x.Employee).Where(x => x.EmployeeId == employeeId).Include(x => x.Employee).ToListAsync();

        }
        public async Task<List<BankDetail>?> GetBankDetailsByIdAsync(Guid employeeId)
        {
            return await _dbContext.BankDetails.Include(x => x.Employee).Where(x => x.EmployeeId == employeeId).Include(x => x.Employee).ToListAsync();

        }
        public async  Task<List<DocumentDetail>?> GetDocumentDetailsByIdAsync(Guid employeeId)
        {
            return await _dbContext.DocumentDetails.Include(x => x.Employee).Where(x => x.EmployeeId == employeeId).Include(x => x.Employee).ToListAsync();

        }
        public async Task<List<PersonalDetail>?> GetPersonalDetailsByIdAsync(Guid employeeId)
        {
            return await _dbContext.PersonalDetails.Include(x => x.Employee).Where(x => x.EmployeeId == employeeId).Include(x => x.Employee).ToListAsync();

        }
        public async Task<EmployeeCredential?> UpdatePassword(Guid employeeId,string resetPassword)
        {
            var employee = await GetCredentialByIdAsync(employeeId);
            if(employee != null)
            {
                employee.Password = resetPassword;
                await _dbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        
        }



    }
}
