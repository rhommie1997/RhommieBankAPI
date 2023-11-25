using RhommieBank.Web.Models;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Abstract
{
    public interface ILoginService
    {
        Task<ResponseDto?> GetResult(UserLoginViewModel user);

    }
}
