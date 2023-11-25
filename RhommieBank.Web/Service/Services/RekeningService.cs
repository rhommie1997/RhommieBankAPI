using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Services
{
    public class RekeningService : IRekeningService
    {

        private readonly IBaseService bs;
        private readonly HttpContext httpContext;
        public RekeningService(IBaseService bs,IHttpContextAccessor httpContextAccessor)
        {
            this.bs = bs;
            httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
        }

        public async Task<ResponseDto?> CreateRekeningAsync(RekeningSaveViewModel rek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = rek,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> DeleteRekeningAsync(string norek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI?norek=" + norek,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetAllRekeningsAsync()
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetRekeningByNorekAsync(string norek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI/" + norek,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> UpdateRekeningAsync(RekeningSaveViewModel rek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = rek,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }
    }
}
