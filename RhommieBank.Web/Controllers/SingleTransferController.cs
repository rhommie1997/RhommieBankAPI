using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.ViewModels;
using RhommieBank.Web.ViewModels.Common;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace RhommieBank.Web.Controllers
{
    public class SingleTransferController : Controller
    {
        private readonly ISingleTransferService singleTransferService;
        private readonly IRekeningService rekeningService;
        public SingleTransferController(ISingleTransferService _sts, IRekeningService _rs)
        {
            singleTransferService = _sts;
            rekeningService = _rs;
        }

        public async Task<IActionResult> Inhouse(ResultMessage result)
        {
            ResponseDto? response = await rekeningService.GetAllRekeningsAsync();

            SingleTransferViewModel newOne = new SingleTransferViewModel();

            List<SingleTransferViewModel> dataList = new List<SingleTransferViewModel>();

            if (response != null && response.IsSuccess)
            {
                var rekenings = JsonConvert.DeserializeObject<List<RekeningViewModel>>(Convert.ToString(response.Result));
                newOne.Rekenings = rekenings.Select(x => new SingleTransferRekeningsViewModel() { 
                    NoRekening = x.no_rekening+"#"+x.saldo,
                    FullName = x.no_rekening+" - "+x.person_name
                }).ToList();
            }
            return View(newOne);
        }




        public IActionResult InhouseConfirmation(SingleTransferViewModel inhouse)
        {
            ClaimsPrincipal cUser = HttpContext.User;
            inhouse.UserName = cUser.Claims.Where(c => c.Type == "username").Select(c => c.Value).SingleOrDefault() ?? "";

            var personId = cUser.Claims.Where(c => c.Type == "PersonID").Select(c => c.Value).SingleOrDefault();

            if(Int32.Parse(personId ?? "0") == 0)
            {
                inhouse.FullName = "Admin";
            }
            else
            {
                inhouse.FullName = "User";
            }

            ResultMessage result = singleTransferService.validate(inhouse);

            if (result.meesageType == "error")
            {
                return RedirectToAction("inhouse", result);
            }

            ViewData["inhouse"] = inhouse;
            return View(inhouse);
        }

        public async Task<IActionResult> InhouseTransaction(SingleTransferViewModel inhouse)
        {
            System.Threading.Thread.Sleep(3000);
            ResponseDto? res = new ResponseDto();

            res = await singleTransferService.TransferInhouse(inhouse);

            inhouse.result = new ResultMessage();

            if (res.IsSuccess)
            {
                inhouse.result.meesageType = "success";
                inhouse.result.meesageName = "This transfer has been successful";
            }
            else
            {
                inhouse.result.meesageType = "failed";
                inhouse.result.meesageName = "This transfer has been failed";
            }

            return View(inhouse);
        }
    }
}
