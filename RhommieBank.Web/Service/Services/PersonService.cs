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
        private readonly HttpContext httpContext;
        public PersonService(IBaseService bs, IHttpContextAccessor httpContextAccessor)
        {
            this.bs = bs;
            httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
        }

        public async Task<ResponseDto?> CreatePersonAsync(PersonAddViewModel dto)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> DeletePersonAsync(int id)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI?id="+id,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetAllPersonsAsync()
        {
            return await bs.SendAsync(new RequestDto() {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetPersonByIDAsync(int id)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI/"+id,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> GetPersonByNameAsync(string name)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI/GetByName/" + name,
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public async Task<ResponseDto?> UpdatePersonAsync(PersonUpdateViewModel dto)
        {
            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = SD.RhommieBankAPIBase + "/api/PersonAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }
    }
}
