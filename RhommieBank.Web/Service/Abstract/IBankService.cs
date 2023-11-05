using RhommieBank.Web.Models;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Abstract
{
    public interface IBankService
    {
        Task<ResponseDto?> GetAllBanksAsync();
        Task<ResponseDto?> CreateBankAsync(BankViewModel bank);
        Task<ResponseDto?> UpdateBankAsync(BankViewModel bank);
        Task<ResponseDto?> GetBankByBankCodeAsync(string BankCode);
        Task<ResponseDto?> DeleteBankAsync(string BankCode);
    }
}
