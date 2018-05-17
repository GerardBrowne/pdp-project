using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using StormPDP.Dtos;
using StormPDP.Models;

namespace StormPDP.Controllers.Api
{
    public class ManagersController : ApiController
    {
        private ApplicationDbContext _context;

        public ManagersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/managers/
        public IEnumerable<ManagerDto> GetManagers()
        {
            return _context.Managers.ToList().Select(Mapper.Map<Manager, ManagerDto>);
        }

        //GET /api/managers/1
        public IHttpActionResult GetManager(int id)
        {
            var manager = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (manager == null)
                return NotFound();

            return Ok(Mapper.Map<Manager, ManagerDto>(manager));
        }

        //POST /api/managers/1
        [HttpPost]
        public IHttpActionResult CreateManager(ManagerDto managerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var manager = Mapper.Map<ManagerDto, Manager>(managerDto);
            _context.Managers.Add(manager);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + manager.Id), managerDto);
        }

        //PUT /api/managers/1
        [HttpPut]
        public void UpdateManager(int id, ManagerDto managerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var managerInDb = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (managerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(managerDto, managerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/managers/1
        [HttpDelete]
        public void DeleteManager(int id)
        {
            var managerInDb = _context.Managers.SingleOrDefault(m => m.Id == id);

            if (managerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Managers.Remove(managerInDb);
            _context.SaveChanges();
        }
    }
}