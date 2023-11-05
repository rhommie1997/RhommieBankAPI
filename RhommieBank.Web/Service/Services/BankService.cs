using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Services
{
    public class BankService : IBankService
    {
        private readonly IBaseService bs;
        public BankService(IBaseService bs)
        {
            this.bs = bs;
        }
        public async Task<ResponseDto?> GetAllBanksAsync()
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI"
            });
        }

        public async Task<ResponseDto?> CreateBankAsync(BankViewModel bank)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = bank,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI"
            });
        }

        public async Task<ResponseDto?> GetBankByBankCodeAsync(string BankCode)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI/" + BankCode
            });
        }

        public async Task<ResponseDto?> UpdateBankAsync(BankViewModel bank)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = bank,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI"
            });
        }

        public async Task<ResponseDto?> DeleteBankAsync(string BankCode)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RhommieBankAPIBase + "/api/BankAPI?BankCode=" + BankCode
            });
        }
    }
}
