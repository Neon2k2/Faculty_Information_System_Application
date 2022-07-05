using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkHistoriesController : ControllerBase
    {
        private IWorkHistoryRepository _repository;
        public WorkHistoriesController(IWorkHistoryRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var WorkList = _repository.GetWorkHistory();
            return Ok(WorkList);

        }
        [HttpPost]
        public IActionResult Post(WorkHistory work)
        {
            WorkHistory obj = _repository.AddWorkHistory(work);
            return CreatedAtAction("get", new
            {
                Id = obj.WorkHistoryId
            }, obj);
        }


        [HttpDelete]
        [Route("{workHistoryId}")]

        public IActionResult Delete(int workHistoryId)
        {
            bool result = _repository.DeleteWorkHistory(workHistoryId);
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
        [Route("{workHistoryId}")]
        public IActionResult Get(int workHistoryId)
        {
            WorkHistory obj = _repository.SearchWorkHistory(workHistoryId);
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
        [Route("{workHistoryId}")]

        public IActionResult Put(int workHistoryId, [FromBody] WorkHistory work)
        {
            _repository.UpdateWorkHistory(workHistoryId, work);
            return Ok();
        }
    }
}
