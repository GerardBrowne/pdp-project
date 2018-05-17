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
    public class DevelopmentPlansController : ApiController
    {
        private ApplicationDbContext _context;

        public DevelopmentPlansController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/developmentplans
        public IEnumerable<DevelopmentPlanDto> GetDevelopmentPlans()
        {
            return _context.DevelopmentPlans
                .Include(e => e.Employee)
                .Include(e => e.Employee.Manager)
                .ToList()
                .Select(Mapper.Map<DevelopmentPlan, DevelopmentPlanDto>);
        }

        //GET api/developmentplans/1
        public IHttpActionResult GetDevelopmentPlan(int id)
        {
            var devPlan = _context.DevelopmentPlans.SingleOrDefault(c => c.Id == id);

            if (devPlan == null)
                return NotFound();

            return Ok(Mapper.Map<DevelopmentPlan, DevelopmentPlanDto>(devPlan));
        }

        //POST /api/developmentplans
        [HttpPost]
        public IHttpActionResult CreateDevelopmentPlan(DevelopmentPlanDto devPlanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var devPlan = Mapper.Map<DevelopmentPlanDto, DevelopmentPlan>(devPlanDto);
            _context.DevelopmentPlans.Add(devPlan);
            _context.SaveChanges();

            devPlanDto.Id = devPlan.Id;

            return Created(new Uri(Request.RequestUri + "/" + devPlan.Id), devPlanDto);
        }

        //PUT /api/developmentplans/1
        [HttpPut]
        public void UpdateDevelopmentPlan(int id, DevelopmentPlanDto devPlanDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var devPlanInDb = _context.DevelopmentPlans.SingleOrDefault(c => c.Id == id);

            if (devPlanInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(devPlanDto, devPlanInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteDevelopmentPlan(int id)
        {
            var devPlanInDb = _context.DevelopmentPlans.SingleOrDefault(c => c.Id == id);

            if (devPlanInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.DevelopmentPlans.Remove(devPlanInDb);
            _context.SaveChanges();
        }
    }
}