using RhommieBank.Web.Models;
using RhommieBank.Web.ViewModels;
using RhommieBank.Web.ViewModels.Common;

namespace RhommieBank.Web.Service.Abstract
{
    public interface ISingleTransferService
    {
        public ResultMessage validate(SingleTransferViewModel data);

        //SingleTransferViewModel
        Task<ResponseDto?> TransferInhouse(SingleTransferViewModel data);

    }
}
