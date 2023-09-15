using AutoMapper;
using HrApi.Attribute;
using HrApi.DTOs;
using HrApi.Models;
using HrApi.Repositories.Interface;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        private readonly IHrApiRepositary _iHrApiRepositary;
        private readonly IMapper _mapper;
        public CredentialController(IHrApiRepositary credentialRepositary, IMapper mapper)
        {
            _iHrApiRepositary = credentialRepositary;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [ValidateModel]
        public async Task<IActionResult> CreateAccount(AddCredentialRequestDTO newCredential)
        {
            object response;

            var employee = await _iHrApiRepositary.GetCredentialAsync(newCredential.Email);

            if (employee != null)
            {
                response = new { Message = "Email already is Exists , Create new one" };
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            var employeesCredential = _mapper.Map<EmployeeCredential>(newCredential);
            await _iHrApiRepositary.AddCredentialAsync(employeesCredential);
            

            response = new { Message = "Credential Added Successfully" };
            return StatusCode(StatusCodes.Status201Created, response);



        }

        [HttpPost("login")]
        [ValidateModel]
        public async Task<IActionResult> VerifyAccount(LoginDTO loginCredential)
        {
            object response;

            var employee = await  _iHrApiRepositary.GetCredentialAsync(loginCredential.Email);

            if (employee != null)
            {
                if (employee.Password == loginCredential.Password)
                {
                    var employeeDetails = await _iHrApiRepositary.GetEmployeeAdminDetailAsync(employee.EmployeeId);
                        
                    response = new { Message = "Account Verified Sucessfully", Data = employeeDetails };

                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    response = new { Message = "Password is Incorrect" };
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }

            }
            else
            {
                response = new { Message = "Email Is Not Found, Create New One" };
                return StatusCode(StatusCodes.Status404NotFound, response);
            }


        }

        [HttpPut("employees/{id}/resetpassword")]
        [ValidateModel]
        public async Task<IActionResult>  ResetPassword(Guid id, ResetPasswordDTO resetPasswordDTO)
        {
            object response;

            var employee = await _iHrApiRepositary.GetCredentialByIdAsync(id);
            if (employee != null)
            {
                if (employee.Password == resetPasswordDTO.OrginalPassword)
                {
                    await _iHrApiRepositary.UpdatePassword(id, resetPasswordDTO.ResetPassword);
                    response = new { Message = "Password Reseted Successfully" };
                    return StatusCode(StatusCodes.Status204NoContent, response);
                }
                else
                {
                    response = new { Message = "Orginal Password Is  Incorrect, Try Again" };
                    return StatusCode(StatusCodes.Status401Unauthorized, response);
                }
            }
            else
            {
                response = new { Message = "Email Is Not Found, Create New One" };
                return StatusCode(StatusCodes.Status404NotFound, response);
            }



        }
    }
}
