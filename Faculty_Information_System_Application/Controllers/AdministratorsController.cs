using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private IAdministratorRepository _repository;
        public AdministratorsController(IAdministratorRepository repository)
        {
            this._repository = repository;
        }

        
        [HttpPost]
        public IActionResult Post(Administrator admin)
        {




            Administrator obj = _repository.AddAdministrator(admin);
            return CreatedAtAction("get", new { Id = obj.AdministratorId }, obj);
        }


        [HttpDelete]
        [Route("{administratorId}")]
        public IActionResult Delete(int administratorId)
        {
           bool result =  _repository.DeleteAdministrator(administratorId);
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
        [AllowAnonymous]
        public IActionResult Get()
        {
            var adminList = _repository.GetAdministrator();
            return Ok(adminList);

        }

        [HttpGet]
        [Route("{administratorId}")]
        public IActionResult Get(int administratorId)
        {
            var adminList = _repository.SearchAdministrator(administratorId);
            return Ok(adminList);

        }


        [HttpPut]
        [Route("{administratorId}")]


        public IActionResult Put(int administratorId, [FromBody] Administrator admin)
        {
            _repository.UpdateAdministrator(administratorId, admin);
            return Ok();
        }

    }
}
