using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;
using Allication.Activities;
using Application;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // get all activities
        [HttpGet]           
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);

        }

        // get activity
        [HttpGet("{id}")]   
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        // create activity
        [HttpPost]          
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command { Activity = activity });
            return Ok();
        }

        // edit activity
        [HttpPut("{id}")]           
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new Edit.Command { Activity = activity });
            return Ok();
        }

        // delete activity
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}
