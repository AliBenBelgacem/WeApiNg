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

namespace WeApiNg.Controllers
{
    public class StudentMastersController : ApiController
    {
        private IRepository db;

        public StudentMastersController(IRepository repository)
        {
            db = repository;
        }
        // GET: api/StudentMasters
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

        // PUT: api/StudentMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentMaster(int id, StudentMaster studentMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentMaster.StdID)
            {
                return BadRequest();
            }

            

            try
            {
                db.SaveStudentMaster(studentMaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentMasters
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult PostStudentMaster(StudentMaster studentMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SaveStudentMaster(studentMaster);
           
            return CreatedAtRoute("DefaultApi", new { id = studentMaster.StdID }, studentMaster);
        }

        // DELETE: api/StudentMasters/5
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult DeleteStudentMaster(int id)
        {
            StudentMaster studentMaster = db.StudentMasters.FirstOrDefault(i=>i.StdID==id);
            if (studentMaster == null)
            {
                return NotFound();
            }

          
            return Ok(studentMaster);
        }

        private bool StudentMasterExists(int id)
        {
            return db.StudentMasters.Count(e => e.StdID == id) > 0;
        }
    }
}