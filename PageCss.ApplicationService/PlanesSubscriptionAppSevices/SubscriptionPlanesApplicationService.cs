using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PageCss.ApplicationService.PlanesSubscription;
using PageCss.DataAccess.Repositories;
using PageCss.Core.Entities;
using PageCss.Core.ViewModelsOut;
using PageCss.Core.ViewModelsIn;

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


        public async Task<int> AddSubscriptionPlanAsync(SubscriptionPlanViewModel subscriptionPlanVM)
        {
            SubscriptionPlan subscriptionPlan = _mapper.Map<SubscriptionPlan>(subscriptionPlanVM);
            await _repository.AddAsync(subscriptionPlan);
            return subscriptionPlan.Id;
        }

        public async Task DeleteSubscriptionPlanAsync(int subscriptionPlanId)
        {
            await _repository.DeleteAsync(subscriptionPlanId);
        }

        public async Task EditSubscriptionPlanAsync(int id, SubscriptionPlanViewModel subscriptionPlanVM)
        {
            SubscriptionPlan subscriptionPlan = _mapper.Map<SubscriptionPlan>(subscriptionPlanVM);
            subscriptionPlan.Id = id;
            await _repository.UpdateAsync(subscriptionPlan);
        }

        public async Task<SubscriptionPlan> GetSubscriptionPlanAsync(int subscriptionPlanId)
        {
            return await _repository.GetAsync(subscriptionPlanId);
        }

        public async Task<List<SubscriptionPlan>> GetSubscriptionPlansAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

    }
}
