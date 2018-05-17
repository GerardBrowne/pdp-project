using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormPDP.Models.Repositories
{
    public interface IManagerRepository
    {
        IQueryable<Manager> Managers { get; }

        Manager Save(Manager managers);


        void Delete(Manager manager);
        void Dispose();
    }
}
