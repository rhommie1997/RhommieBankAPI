using RhommieBank.Web.Models;

namespace RhommieBank.Web.Service.Abstract
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto reqDto);
    }
}
