using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Service.Services;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Controllers
{
    public class BankController : Controller
    {

        private readonly IBankService bankService;

        public BankController(IBankService bs)
        {
            this.bankService = bs;
        }

        public async Task<IActionResult> Index()
        {
            List<BankViewModel>? listBank = new();

            

            ResponseDto? response = await bankService.GetAllBanksAsync();
            if (response != null && response.IsSuccess)
            {
                listBank = JsonConvert.DeserializeObject<List<BankViewModel>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["Error"] = response.Message;
            }

            return View(listBank);
        }

        public async Task<IActionResult> Add()
        {
            return View("_Add");
        }

        public async Task<IActionResult> Save(string Type, BankViewModel data)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? res = new ResponseDto();

                if (Type == "Add")
                {
                    res = await bankService.CreateBankAsync(data);
                }
                else
                {
                    res = await bankService.UpdateBankAsync(data);
                }

                if (res != null && res.IsSuccess)
                {
                    if (Type == "Add")
                    {
                        TempData["Success"] = "Person successfully created";
                    }
                    else
                    {
                        TempData["Success"] = "Person successfully updated";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = res.Message;
                }
            }

            return View(data);
        }

        public async Task<IActionResult> Update(string code)
        {
            ResponseDto? res = await bankService.GetBankByBankCodeAsync(code);
            if (res != null && res.IsSuccess)
            {
                BankViewModel bank = JsonConvert.DeserializeObject<BankViewModel>(Convert.ToString(res.Result));

                return View("_Edit", bank);
            }
            else
            {
                TempData["Error"] = res.Message;
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(string code)
        {
            ResponseDto? res = await bankService.DeleteBankAsync(code);
            if (res != null && res.IsSuccess)
            {
                TempData["Success"] = "Person successfully deleted";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = res.Message;
            }


            return NotFound();
        }


    }
}
