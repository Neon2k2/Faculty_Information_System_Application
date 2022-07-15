using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminstratorSearchController : ControllerBase
    {
        private readonly IAdministratorSearchRepository _repository;

        public AdminstratorSearchController(IAdministratorSearchRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{adminName}")]

        public IActionResult Get(string adminName)
        {
            Administrator obj = _repository.SearchAdministratorByName(adminName);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }
    }



}
