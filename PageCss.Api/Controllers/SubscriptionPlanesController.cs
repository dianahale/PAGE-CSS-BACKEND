using Microsoft.AspNetCore.Mvc;
using PageCss.ApplicationService.PlanesSubscription;
using PageCss.Core.Entities;
using PageCss.Core.ViewModelsOut;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET ALL SUBSCRIPTION PLANS
        [HttpGet]
        public async Task<IEnumerable<SubscriptionPlanViewModelOut>> Get()
        {
            List<SubscriptionPlanViewModelOut> subscriptionPlans = await _subsPlanAppService.GetSubscriptionPlansAsync();
            return subscriptionPlans;
        }

        // GET SUBSCRIPTION PLAN BY ID
        [HttpGet("{id}")]
        public async Task<SubscriptionPlan> Get(int id)
        {
            SubscriptionPlan subscriptionPlan = await _subsPlanAppService.GetSubscriptionPlanAsync(id);
            return subscriptionPlan;
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
