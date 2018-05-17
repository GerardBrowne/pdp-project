using System.Linq;
using StormPDP.ViewModels;

namespace StormPDP.Models.Repositories
{
    public interface IDevelopmentPlanRepository
    {
        IQueryable<DevelopmentPlan> DevelopmentPlans { get; }

        DevPlanFormViewModel SaveDevelopmentPlan(DevPlanFormViewModel model);

        DevPlanFormViewModel NewDevelopmentPlan();

        DevPlanFormViewModel EditDevelopmentPlan(int id);

        void Delete(DevelopmentPlan developmentPlan);

        void Dispose();
    }
}
