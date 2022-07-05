using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private IDesignationRepository _repository;
        public DesignationsController(IDesignationRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var DesigList = _repository.GetDesignation();
            return Ok(DesigList);

        }
        [HttpPost]
        public IActionResult Post(Designation desig)
        {
            Designation obj = _repository.AddDesignation(desig);
            return CreatedAtAction("get", new
            {
                Id = obj.DesignationId
            }, obj);
        }


        [HttpDelete]
        [Route("{designationId}")]
        public IActionResult Delete(int designationId)
        {
            bool result = _repository.DeleteDesignation(designationId);
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
        [Route("{designationId}")]
        public IActionResult Get(int designationId)
        {
            Designation obj = _repository.SearchDesignation(designationId);
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
        [Route("{designationId}")]
        public IActionResult Put(int designationId, [FromBody] Designation desig)
        {
            _repository.UpdateDesignation(designationId, desig);
            return Ok();
        }
    }
}
