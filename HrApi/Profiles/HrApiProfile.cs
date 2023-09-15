using AutoMapper;
using HrApi.DTOs;
using HrApi.Models;

namespace HrApi.Profiles
{
    public class HrApiProfile : Profile
    {
        public  HrApiProfile() 
        {
            CreateMap<EmployeeCredential, AddCredentialRequestDTO>().ReverseMap();
            CreateMap<AddFamilyDetailRequestDTO, FamilyDetail>().ReverseMap();
            CreateMap<AddEducationDetailDTO, EducationDetail>().ReverseMap();
            CreateMap<AddBankDetailDTO, BankDetail>().ReverseMap();
            CreateMap<AddDocumentDetailDTO, DocumentDetail>().ReverseMap();
            CreateMap<AddPersonalDetaillDTO, PersonalDetail>().ReverseMap();
        }
        //FAM ED BANK DOCUMENT PERSONAL
    }
}
