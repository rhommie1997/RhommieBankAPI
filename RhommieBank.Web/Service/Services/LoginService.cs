using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IBaseService bs;
        public LoginService(IBaseService bs)
        {
            this.bs = bs;
        }

        public async Task<ResponseDto?> GetResult(UserLoginViewModel user)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = user,
                Url = SD.RhommieBankAPIBase + "/api/LoginAPI"
            });
        }
    }
}
