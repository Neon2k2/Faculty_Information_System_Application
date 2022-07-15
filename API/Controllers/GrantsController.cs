using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrantsController : ControllerBase
    {
        private readonly IGrantRepository _repository;
        public GrantsController(IGrantRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var GrantList = _repository.GetGrant();
            return Ok(GrantList);

        }
        [HttpPost]
        public IActionResult Post(Grant gran)
        {
            Grant obj = _repository.AddGrant(gran);
            return CreatedAtAction("get", new
            {
                Id = obj.GrantId
            }, obj);
        }


        [HttpDelete]
        [Route("{grantId}")]
        public IActionResult Delete(int grantId)
        {
            bool result = _repository.DeleteGrant(grantId);
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
        [Route("{grantId}")]
        public IActionResult Get(int grantId)
        {
            Grant obj = _repository.SearchGrant(grantId);
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
        [Route("{grantId}")]

        public IActionResult Put(int grantId, [FromBody] Grant gran)
        {
            _repository.UpdateGrant(grantId, gran);
            return Ok();
        }
    }
}
