using AutoMapper;
using HrApi.DTOs;
using HrApi.Models;
using HrApi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrApiController : ControllerBase
    {
        private readonly IHrApiRepositary _iHrApiRepositary;
        private readonly IMapper _mapper;
        public HrApiController(IHrApiRepositary iHrApiRepositary, IMapper mapper)
        {
            _iHrApiRepositary = iHrApiRepositary;
            _mapper = mapper;
        }
        // employees/{id}
        //FAM ED BANK DOCUMENT PERSONAL
        [HttpPost("employees/{id}/family-detail")]
        public async Task<IActionResult> AddFamily(Guid employeeId,AddFamilyDetailRequestDTO familyDetailRequestDTO)
        {
           var employee = await _iHrApiRepositary.GetEmployeeAdminDetailAsync(employeeId);
            if(employee != null)
            {
                FamilyDetail familyDetail = _mapper.Map<FamilyDetail>(familyDetailRequestDTO);
                await _iHrApiRepositary.AddFamilyAsync(familyDetail);
                return Ok(familyDetail);
            }
            return BadRequest(employeeId);
        }
        [HttpPost("employees/{id}/education-detail")]
        public async Task<IActionResult> AddEducation(Guid employeeId, AddEducationDetailDTO educationDetailDTO)
        {
            var employee = await _iHrApiRepositary.GetEmployeeAdminDetailAsync(employeeId);
            if (employee != null)
            {
                EducationDetail educationDetail = _mapper.Map<EducationDetail>(educationDetailDTO);
                await _iHrApiRepositary.AddEducationAsync(educationDetail);
                return Ok(educationDetail);
            }
            return BadRequest(employeeId);
        }

        [HttpPost("employees/{id}/bank-detail")]
        public async Task<IActionResult> AddBank(Guid employeeId, AddBankDetailDTO bankDetailDTO)
        {
            var employee = await _iHrApiRepositary.GetEmployeeAdminDetailAsync(employeeId);
            if (employee != null)
            {
                BankDetail bankDetail = _mapper.Map<BankDetail>(bankDetailDTO);
                await _iHrApiRepositary.AddBankAsync(bankDetail);
                return Ok(bankDetail);
            }
            return BadRequest(employeeId);
        }

        [HttpPost("employees/{id}/familydetail")]
        public async Task<IActionResult> AddDocument(Guid employeeId, AddDocumentDetailDTO documentDetailDTO)
        {
            var employee = await _iHrApiRepositary.GetEmployeeAdminDetailAsync(employeeId);
            if (employee != null)
            {
                DocumentDetail documentDetail = _mapper.Map<DocumentDetail>(documentDetailDTO);
                await _iHrApiRepositary.AddDocumentAsync(documentDetail);
                return Ok(documentDetail);
            }
            return BadRequest(employeeId);
        }

        [HttpPost("employees/{id}/personal-details")]
        public async Task<IActionResult> AddPersonal(Guid employeeId, AddPersonalDetaillDTO personalDetaillDTO)
        {
            var employee = await _iHrApiRepositary.GetEmployeeAdminDetailAsync(employeeId);
            if (employee != null)
            {
                PersonalDetail personalDetail = _mapper.Map<PersonalDetail>(personalDetaillDTO);
                await _iHrApiRepositary.AddPersonalAsync(personalDetail);
                return Ok(personalDetail);
            }
            return BadRequest(employeeId);
        }
        // employees/{id}
        //FAM ED BANK DOCUMENT PERSONAL
        [HttpGet("employees/{id}/family-details")]
        public async Task<IActionResult> GetFamilies(Guid employeeId)
        {
            var families = await _iHrApiRepositary.GetFamilyDetailsByIdAsync(employeeId);
            return Ok(families);
        }
        [HttpGet("employees/{id}/family-details")]
        public async Task<IActionResult> GetEducationDetails(Guid employeeId)
        {
            var educationDetails = await _iHrApiRepositary.GetEducationDetailsByIdAsync(employeeId);
            return Ok(educationDetails);
        }
        [HttpGet("employees/{id}/family-details")]
        public async Task<IActionResult> GetBankDetails(Guid employeeId)
        {
            var bankDetails = await _iHrApiRepositary.GetBankDetailsByIdAsync(employeeId);
            return Ok(bankDetails);
        }
        [HttpGet("employees/{id}/family-details")]
        public async Task<IActionResult> GetDocumentDetails(Guid employeeId)
        {
            var documentDetails = await _iHrApiRepositary.GetDocumentDetailsByIdAsync(employeeId);
            return Ok(documentDetails);
        }
        [HttpGet("employees/{id}/family-details")]
        public async Task<IActionResult> GetPersonal(Guid employeeId)
        {
            var personalDetails = await _iHrApiRepositary.GetPersonalDetailsByIdAsync(employeeId);
            return Ok(personalDetails);
        }

    }
}
