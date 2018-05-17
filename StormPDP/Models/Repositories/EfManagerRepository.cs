using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StormPDP.Models.Repositories
{
    public class EfManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Manager> Managers => _context.Managers;
        public Manager Save(Manager manager)
        {
            if (manager.Id == 0)
            {
                _context.Managers.Add(manager);
            }
            else
            {
                _context.Entry(manager).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return manager;
        }

        public void Delete(Manager manager)
        {
            _context.Managers.Remove(manager);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}