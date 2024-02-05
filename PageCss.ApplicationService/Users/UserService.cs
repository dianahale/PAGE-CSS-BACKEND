using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PageCss.DataAccess;
using PageCss.Core.ViewModelsOut;
using PageCss.Core.ViewModelsIn;
using PageCss.Core.Entities;
using PageCss.ApplicationService.PlanesSubscription;

namespace PageCss.ApplicationServices.Users
{
    public class UserService: IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly PageCssContext _context;
        private readonly ISubscriptionPlanesApplicationService _planSubscription;
        private readonly IMapper _mapper;
 
        public UserService(
            UserManager<User> userManager, 
            PageCssContext context, 
            IMapper mapper,
            ISubscriptionPlanesApplicationService planSubscription
        ){
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _planSubscription = planSubscription;
        }

        public async Task<UsersViewModelOut> GetUserAsync(string id)
        {
            IdentityUser user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            UsersViewModelOut userVM = _mapper.Map<UsersViewModelOut>(user);

            return userVM;
        }

        public async Task<IdentityResult> AddUserAsync(UsersViewModelIn usersViewModelIn)
        {

            User userNew = new User{
                Email = usersViewModelIn.Email,
                EmailConfirmed = true,
                UserName = usersViewModelIn.Email,
                PhoneNumber = usersViewModelIn.PhoneNumber
            };

            userNew.SubscriptionPlans.Id = usersViewModelIn.SubscriptionPlanId;
            Console.WriteLine("dfcgvhbh");
            
            var result = await _userManager.CreateAsync(
                userNew
                //new User{
                //    Email = usersViewModelIn.Email,
                //    EmailConfirmed = true,
                //    UserName = usersViewModelIn.Email,
                //    PhoneNumber = usersViewModelIn.PhoneNumber}
            , usersViewModelIn.Password);

            return result;

        }

    }
}
