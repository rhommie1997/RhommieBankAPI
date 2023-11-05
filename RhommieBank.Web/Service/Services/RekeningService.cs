using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Services
{
    public class RekeningService : IRekeningService
    {

        private readonly IBaseService bs;
        public RekeningService(IBaseService bs)
        {
            this.bs = bs;
        }

        public async Task<ResponseDto?> CreateRekeningAsync(RekeningSaveViewModel rek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = rek,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI"
            });
        }

        public async Task<ResponseDto?> DeleteRekeningAsync(string norek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI?norek=" + norek
            });
        }

        public async Task<ResponseDto?> GetAllRekeningsAsync()
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI"
            });
        }

        public async Task<ResponseDto?> GetRekeningByNorekAsync(string norek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI/" + norek
            });
        }

        public async Task<ResponseDto?> UpdateRekeningAsync(RekeningSaveViewModel rek)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = rek,
                Url = SD.RhommieBankAPIBase + "/api/RekeningAPI"
            });
        }
    }
}
