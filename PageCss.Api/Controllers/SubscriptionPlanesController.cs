using Microsoft.AspNetCore.Mvc;
using PageCss.ApplicationService.PlanesSubscription;
using PageCss.Core.Entities;
using PageCss.Core.ViewModelsIn;

namespace PageCss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanesController : ControllerBase
    {
        private readonly ISubscriptionPlanesApplicationService _subsPlanAppService;

        public SubscriptionPlanesController(ISubscriptionPlanesApplicationService subsPlanAppService)
        {
            _subsPlanAppService = subsPlanAppService;
        }

        // GET: ALL SUBSCRIPTION PLANS
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SubscriptionPlan> subscriptionPlans = await _subsPlanAppService.GetSubscriptionPlansAsync();
            return Ok( new
            {
                HasError = false,
                Message = "List of subcription plans returned",
                Model = subscriptionPlans,
                RequestId = System.Diagnostics.Activity.Current?.Id
            });
        }

        // GET: SUBSCRIPTION PLAN BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            SubscriptionPlan subscriptionPlan = await _subsPlanAppService.GetSubscriptionPlanAsync(id);
            return Ok(new {
                HasError = false,
                Message = "Plan returned",
                Model = subscriptionPlan,
                RequestId = System.Diagnostics.Activity.Current?.Id
            });
        }

        // POST: ADD NEW SUBSCRIPTION PLAN
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubscriptionPlanViewModel subscriptionPlan)
        {
            if (ModelState.IsValid){
                int id=await _subsPlanAppService.AddSubscriptionPlanAsync(subscriptionPlan);
                return Ok(new{
                    hasError = false,
                    message = "Plan Registered",
                    model = await _subsPlanAppService.GetSubscriptionPlanAsync(id),
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }else{
                return BadRequest(new{
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }

        }

        // PUT: EDIT SUBSCRIPTION PLAN
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SubscriptionPlanViewModel subscriptionPlan)
        {
            if (ModelState.IsValid){
                await _subsPlanAppService.EditSubscriptionPlanAsync(id,subscriptionPlan);
                return Ok(new{
                    hasError = false,
                    message = "Plan Updated",
                    model = await _subsPlanAppService.GetSubscriptionPlanAsync(id),
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
            else{
                return BadRequest(new{
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }

        // DELETE SUBSCRIPTION PLAN
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid){
                await _subsPlanAppService.DeleteSubscriptionPlanAsync(id);
                return Ok(new{
                    hasError = false,
                    message = "Plan Deleted",
                    model = await _subsPlanAppService.GetSubscriptionPlansAsync(),
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
            else{
                return BadRequest(new{
                    hasError = true,
                    message = "Bad Request",
                    model = new { title = "Bad Request", message = "Your request is incorrect, verify it" },
                    requestId = System.Diagnostics.Activity.Current?.Id
                });
            }
        }


    }
}
