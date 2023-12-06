using RhommieBank.Web.Models;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Service.Abstract
{
    public interface IBankService
    {
        Task<ResponseDto?> GetAllBanksAsync();
        Task<ResponseDto?> CreateBankAsync(BankSaveViewModel bank);
        Task<ResponseDto?> UpdateBankAsync(BankSaveViewModel bank);
        Task<ResponseDto?> GetBankByBankCodeAsync(string BankCode);
        Task<ResponseDto?> DeleteBankAsync(string BankCode);
        Task<ResponseDto?> GetAllCurrenciesAsync();
    }
}
