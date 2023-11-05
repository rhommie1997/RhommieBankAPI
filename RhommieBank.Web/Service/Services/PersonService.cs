using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;
using static RhommieBank.Web.Util.SD;

namespace RhommieBank.Web.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IBaseService bs;
        public PersonService(IBaseService bs)
        {
            this.bs = bs;
        }

        public async Task<ResponseDto?> CreatePersonAsync(PersonAddViewModel dto)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI"
            });
        }

        public async Task<ResponseDto?> DeletePersonAsync(int id)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI?id="+id
            });
        }

        public async Task<ResponseDto?> GetAllPersonsAsync()
        {
            return await bs.SendAsync(new RequestDto() {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI"
            });
        }

        public async Task<ResponseDto?> GetPersonByIDAsync(int id)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI/"+id
            });
        }

        public async Task<ResponseDto?> GetPersonByNameAsync(string name)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI/GetByName/" + name
            });
        }

        public async Task<ResponseDto?> UpdatePersonAsync(PersonUpdateViewModel dto)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI"
            });
        }
    }
}
