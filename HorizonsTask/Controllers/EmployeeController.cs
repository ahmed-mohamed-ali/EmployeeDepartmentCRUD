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
using HorizonsTask.Models;

namespace HorizonsTask.Controllers
{
    public class EmployeeController : ApiController
    {
        private HorizonsContext db = new HorizonsContext();

        // GET: api/Employee
        public IHttpActionResult GetEmployees()
        {
            
            var emps = db.Employees.ToList();
            if (emps.Count > 0)
            {
                return Ok(emps);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Employee/5
        
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Include(e=>e.Department).FirstOrDefault(em=>em.Id==id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employee/5
     
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }
            employee.Department = db.Departments.Find(employee.DepartmentId);
            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return InternalServerError();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee
        
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            employee.Department = db.Departments.Find(employee.DepartmentId);
            db.Employees.Add(employee);
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                //error not defined
                    return InternalServerError();
              
            }
         

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employee/5
        
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                //error not defined
                return InternalServerError();

            }

            return Ok(employee);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}