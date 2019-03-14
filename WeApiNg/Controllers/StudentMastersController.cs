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
using WeApiNg.Abstract;
using WeApiNg.Concrete;
using WeApiNg.Models;
using System.Web.Http.Cors;

namespace WeApiNg.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class StudentMastersController : ApiController
    {
        private IRepository db;

        public StudentMastersController(IRepository repository)
        {
            db = repository;
        }
        // GET: api/StudentMasters
        [HttpGet]
        [Route("api/StudentMasters")]
        public IEnumerable<StudentMaster> GetStudentMasters()
        {
            return db.StudentMasters;
        }

        // GET: api/StudentMasters/5
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult GetStudentMaster(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.FirstOrDefault(i=>i.StdID==id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            return Ok(studentMaster);
        }

        //// PUT: api/StudentMasters/5
        //[ResponseType(typeof(void))]
        //[HttpPatch]
        //[Route("api/StudentMasters")]
        //public IHttpActionResult PutStudentMaster(int id, StudentMaster studentMaster)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != studentMaster.StdID)
        //    {
        //        return BadRequest();
        //    }            

        //    try
        //    {
        //        db.SaveStudentMaster(studentMaster);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentMasterExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //   return StatusCode(HttpStatusCode.NoContent);
        //}
        // PUT: api/StudentMasters/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/StudentMasters/{id}")]
        public IHttpActionResult PutchStudentMaster(StudentMaster studentMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != studentMaster.StdID)
            //{
            //    return BadRequest();
            //}

            try
            {
                db.SaveStudentMaster(studentMaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!StudentMasterExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentMasters
        [ResponseType(typeof(StudentMaster))]
        [HttpPost]
        [Route("api/StudentMasters")]
        public IHttpActionResult PostStudentMaster(StudentMaster studentMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SaveStudentMaster(studentMaster);

            return Ok(studentMaster);// CreatedAtRoute("DefaultApi", new { id = studentMaster.StdID }, studentMaster);
        }

        // DELETE: api/StudentMasters/5
        [ResponseType(typeof(StudentMaster))]
        [HttpDelete]
        [Route("api/StudentMasters/{id}")]
        public IHttpActionResult DeleteStudentMaster(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.FirstOrDefault(i=>i.StdID==id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            db.DeleteStudentMaster(id);

            return Ok(studentMaster);
        }

        private bool StudentMasterExists(int id)
        {
            return db.StudentMasters.Count(e => e.StdID == id) > 0;
        }
    }
}