using AutoMapper;
using StormPDP.Dtos;
using StormPDP.Models;
using StormPDP.ViewModels;

namespace StormPDP
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Employee, EmployeeDto>();
            CreateMap<DevelopmentPlan, DevelopmentPlanDto>();
            CreateMap<Manager, ManagerDto>();
            CreateMap<EmployeeSkill, EmployeeSkillDto>();
            CreateMap<Skill, SkillDto>();
            CreateMap<TrainingPlan, TrainingPlanDto>();
            CreateMap<Objective, ObjectiveDto>();
            CreateMap<DevPlanFormViewModel, DevelopmentPlan>();
            CreateMap<DevPlanFormViewModel, TrainingPlanDto>();
            CreateMap<DevPlanFormViewModel, ObjectiveDto>();
            CreateMap<DevPlanFormViewModel, EmployeeSkillDto>();
            CreateMap<DevPlanFormViewModel, EmployeeDto>();
            CreateMap<EmployeeSkill, DevPlanFormViewModel>();
            CreateMap<EmployeeFormViewModel, Employee>();
            CreateMap<EmployeeFormViewModel, EmployeeSkill>();
            CreateMap<EmployeeFormViewModel, TrainingPlan>();
            CreateMap<EmployeeFormViewModel, Objective>();
            CreateMap<Employee, EmployeePlanDto>();


            //Dto to Domain
            CreateMap<EmployeeDto, Employee>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<DevelopmentPlanDto, DevelopmentPlan>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<EmployeePlanDto, Employee>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}