using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPractice.Model.Request;

namespace WebAPIPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok("this is a employee data");
        }

        //for two get methods it will get error to get rid of that we need to do the action added in Route
        [HttpGet]
        public IActionResult GetEmployeesData(string Empid)
        {
            return Ok("this is a another get employee data");
        }

        // [HttpPost]
        // public IActionResult InsertEmployeeData(string name, string phoneno)
        // {
        //     return Ok("this is a employee Inserted Data");
        // }

        [HttpPost]
        public IActionResult InsertEmployeeData(EmployeeRequest employeeRequest)
        {
            return Ok(employeeRequest);
        }
        
        // [HttpDelete]
        // public IActionResult DeleteEmployeeData(int Empid)
        // {
        //     return Ok("this is a employee Deleted Data");
        // }
        
        //by giving dynamic routing  value passing we can set the fields like not negative like that 
        [HttpDelete("{Empid:min(1)}")]
        public IActionResult DeleteEmployeeData(int Empid)
        {
            return Ok("this is a employee Deleted Data");
        }
    }
}
