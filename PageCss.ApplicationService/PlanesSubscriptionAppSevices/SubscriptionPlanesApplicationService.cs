using PageCss.ApplicationService.PlanesSubscription;
using PageCss.Core.Entities;
using Microsoft.EntityFrameworkCore;
using PageCss.DataAccess.Repositories;
using PageCss.Core.ViewModelsOut;
using AutoMapper;

namespace PageCss.ApplicationService.PlanesSubscriptionAppServices
{
    public class SubscriptionPlanesApplicationService : ISubscriptionPlanesApplicationService
    {

        private readonly IRepository<int, SubscriptionPlan> _repository;
        private readonly IMapper _mapper;

        public SubscriptionPlanesApplicationService(
            IRepository<int, SubscriptionPlan> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<int> AddSubscriptionPlanAsync(SubscriptionPlan subscriptionPlan)
        {
            await _repository.AddAsync(subscriptionPlan);

            return subscriptionPlan.Id;
        }

        public async Task DeleteSubscriptionPlanAsync(int subscriptionPlanId)
        {
            await _repository.DeleteAsync(subscriptionPlanId);
        }

        public async Task EditSubscriptionPlanAsync(SubscriptionPlan subscriptionPlan)
        {
            await _repository.UpdateAsync(subscriptionPlan);
        }

        public async Task<SubscriptionPlan> GetSubscriptionPlanAsync(int subscriptionPlanId)
        {
            return await _repository.GetAsync(subscriptionPlanId);
        }

        public async Task<List<SubscriptionPlanViewModelOut>> GetSubscriptionPlansAsync()
        {
            List<SubscriptionPlan> subsPlans = await _repository.GetAll().ToListAsync();
            return _mapper.Map<List<SubscriptionPlanViewModelOut>>(subsPlans);
        }
    }
}
