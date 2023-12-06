using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Services
{
    public class BankService : IBankService
    {
        private readonly IBaseService bs;
        private readonly HttpContext httpContext;
        public BankService(IBaseService bs, IHttpContextAccessor httpContextAccessor)
        {
            this.bs = bs;
            httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
        }
        public async Task<ResponseDto?> GetAllBanksAsync()
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> CreateBankAsync(BankSaveViewModel bank)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = bank,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetBankByBankCodeAsync(string BankCode)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI/" + BankCode,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> UpdateBankAsync(BankSaveViewModel bank)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = bank,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> DeleteBankAsync(string BankCode)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI?BankCode=" + BankCode,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetAllCurrenciesAsync()
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/CurrencyAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }
    }
}
