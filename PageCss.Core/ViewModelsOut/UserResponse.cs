using PageCss.Core.ViewModelsOut;

namespace Inventario.Api.Responses
{
    public class UserResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public UsersViewModelOut Model { get; set; }
        public string RequestId { get; set; }
    }
}
