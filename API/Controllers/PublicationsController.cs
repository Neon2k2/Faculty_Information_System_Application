using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationRepository _repository;
        public PublicationsController(IPublicationRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var PublishList = _repository.GetPublication();
            return Ok(PublishList);

        }
        [HttpPost]
        public IActionResult Post(Publication publish)
        {
            Publication obj = _repository.AddPublication(publish);
            return CreatedAtAction("get", new
            {
                Id = obj.PublicationId
            }, obj);
        }


        [HttpDelete]
        [Route("{publicationId}")]
        public IActionResult Delete(int publicationId)
        {
            bool result = _repository.DeletePublication(publicationId);
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
        [Route("{publicationId}")]
        public IActionResult Get(int publicationId)
        {
            Publication obj = _repository.SearchPublication(publicationId);
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
        [Route("{publicationId}")]
        public IActionResult Put(int publicationId, [FromBody] Publication publish)
        {
            _repository.UpdatePublication(publicationId, publish);
            return Ok();
        }
    }
}
