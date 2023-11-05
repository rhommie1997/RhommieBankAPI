using RhommieBank.Web.Models;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Abstract
{
    public interface IPersonService
    {
        Task<ResponseDto?> GetPersonByIDAsync(int id);
        Task<ResponseDto?> GetPersonByNameAsync(string name);
        Task<ResponseDto?> GetAllPersonsAsync();
        Task<ResponseDto?> CreatePersonAsync(PersonAddViewModel name);
        Task<ResponseDto?> UpdatePersonAsync(PersonUpdateViewModel name);
        Task<ResponseDto?> DeletePersonAsync(int id);
    }
}
