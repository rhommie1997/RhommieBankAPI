using Microsoft.AspNetCore.Http;
using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Util;
using RhommieBank.Web.ViewModels;
using RhommieBank.Web.ViewModels.Common;

namespace RhommieBank.Web.Service.Services
{
    public class SingleTransferService : ISingleTransferService
    {
        private readonly IBaseService bs;
        private readonly HttpContext httpContext;

        public SingleTransferService(IBaseService bs, IHttpContextAccessor httpContextAccessor)
        {
            this.bs = bs;
            httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor.HttpContext));
        }


        public async Task<ResponseDto?> TransferInhouse(SingleTransferViewModel data)
        {
            var newOne = new SingTransferSendAPIViewModel() {
                username = data.UserName,
                transferFrom = data.TransferFrom,
                transferTo = data.TransferTo,
                transactionName = "Single Transfer Inhouse",
                transactionTypeID = 1,
                amount = data.Amount,
                description = data.Description,
                transferDate = DateTime.Now,
                createdBy = data.FullName,
                createdDt = DateTime.Now
            };


            return await bs.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = newOne,
                Url = SD.RhommieBankAPIBase + "/api/SingleTransferAPI",
                AccessToken = httpContext.User.Claims.FirstOrDefault(x => x.Type == "token")?.Value ?? ""
            });
        }

        public ResultMessage validate(SingleTransferViewModel data)
        {
            ResultMessage result = new ResultMessage();

            if (data.TransferFrom == null)
            {
                result.meesageType = "error";
                result.meesageName = "Transfer from cant be empty !!";
            }
            else if (data.TransferTo == null)
            {
                result.meesageType = "error";
                result.meesageName = "Transfer to cant be empty !!";
            }
            else if (data.Amount < 10000)
            {
                result.meesageType = "error";
                result.meesageName = "Balance minimum is 10000 !!";
            }
            else
            {
                result.meesageType = "success";
                result.meesageName = "Validation success";
            }

            return result;
        }
    }
}
