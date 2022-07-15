using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleLookupController : ControllerBase
    {
        private readonly IRoleLookupRepository _repository;

        public RoleLookupController(IRoleLookupRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roleList = _repository.GetRoleLookup();
            return Ok(roleList);
        }
    }
}
