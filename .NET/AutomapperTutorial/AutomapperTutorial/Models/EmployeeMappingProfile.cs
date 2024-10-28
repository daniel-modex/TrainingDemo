using AutoMapper;

namespace AutomapperTutorial.Models
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile() 
        {
            CreateMap<Employee,EmployeeDTO>();
            CreateMap<EmployeeDTO,Employee>();
        }
    }
}
