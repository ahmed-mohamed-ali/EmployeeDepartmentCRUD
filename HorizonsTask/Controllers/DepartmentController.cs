using HorizonsTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HorizonsTask.Controllers
{
    public class DepartmentController : ApiController
    {
    private HorizonsContext db = new HorizonsContext();

        // GET: api/Department
        public IHttpActionResult GetDepartments()
        {

            var deps = db.Departments.ToList();
            if (deps.Count > 0)
            {
                return Ok(deps);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
