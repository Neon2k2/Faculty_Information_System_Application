using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartment _repository;
        public DepartmentsController(IDepartment repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var DeptList = _repository.GetDepartment();
            return Ok(DeptList);

        }
        [HttpPost]
        public IActionResult Post(Department dept)
        {
            Department obj = _repository.AddDepartment(dept);
            return CreatedAtAction("get", new { Id = obj.DepartmentId
            }, obj);
        }


        [HttpDelete]
        [Route("{departmentId}")]
        public IActionResult Delete(int departmentId)
        {
            bool result = _repository.DeleteDepartment(departmentId);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{departmentId}")]
        public IActionResult Get(int departmentId)
        {
            Department obj = _repository.SearchDepartment(departmentId);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{departmentId}")]

        public IActionResult Put(int departmentId, [FromBody] Department dept)
        {
            _repository.UpdateDepartment(departmentId, dept);
            return Ok();
        }
    }
}
