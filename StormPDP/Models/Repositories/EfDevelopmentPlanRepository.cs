using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using StormPDP.ViewModels;

namespace StormPDP.Models.Repositories
{
    public class EfDevelopmentPlanRepository : IDevelopmentPlanRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<DevelopmentPlan> DevelopmentPlans => _context.DevelopmentPlans.Include(d => d.Employee);

        public DevPlanFormViewModel SaveDevelopmentPlan(DevPlanFormViewModel model)
        {
            if (model.DevelopmentPlan.Id == 0)
            {
                _context.DevelopmentPlans.Add(model.DevelopmentPlan);
            }
            else
            {
                _context.Entry(model.DevelopmentPlan).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return model;
        }

        public DevPlanFormViewModel NewDevelopmentPlan()
        {
            var employees = _context.Employees.ToList();

            var viewModel = new DevPlanFormViewModel
            {
                DevelopmentPlan = new DevelopmentPlan(),
                Employees = employees,
                Skills = _context.Skills.Select(d => new SelectListItem
                {
                    Value = d.SkillId.ToString(),
                    Text = d.Name
                })
            };
            return viewModel;
        }

        public DevPlanFormViewModel EditDevelopmentPlan(int id)
        {
            var employees = _context.Employees.ToList();
            var devPlan = _context.DevelopmentPlans.SingleOrDefault(d => d.Id == id);

            var viewModel = new DevPlanFormViewModel
            {
                DevelopmentPlan = devPlan,
                Employees = employees,
                Skills = _context.Skills.Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.SkillId.ToString()
                }),
            };
            return viewModel;
        }

        public void Delete(DevelopmentPlan developmentPlan)
        {
            _context.DevelopmentPlans.Remove(developmentPlan);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}