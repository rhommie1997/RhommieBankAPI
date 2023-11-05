using RhommieBank.Web.Models;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Abstract
{
    public interface IRekeningService
    {
        Task<ResponseDto?> GetAllRekeningsAsync();
        Task<ResponseDto?> CreateRekeningAsync(RekeningSaveViewModel name);
        Task<ResponseDto?> UpdateRekeningAsync(RekeningSaveViewModel name);
        Task<ResponseDto?> GetRekeningByNorekAsync(string norek);
        Task<ResponseDto?> DeleteRekeningAsync(string norek);

    }
}
