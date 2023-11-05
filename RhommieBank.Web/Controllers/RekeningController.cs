using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.Service.Services;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Controllers
{
    public class RekeningController : Controller
    {
        private readonly IRekeningService rekeningService;
        private readonly IPersonService personService;
        private readonly IBankService bankService;

        public RekeningController(IRekeningService rs, IPersonService ps, IBankService bs)
        {
            rekeningService = rs;
            personService = ps;
            bankService = bs;
        }


        public async Task<IActionResult> Index()
        {
            List<RekeningViewModel>? listRekening = new();

            ResponseDto? response = await rekeningService.GetAllRekeningsAsync();
            if (response != null && response.IsSuccess)
            {
                listRekening = JsonConvert.DeserializeObject<List<RekeningViewModel>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["Error"] = response.Message;
            }

            return View(listRekening);
        }

        public async Task<IActionResult> Add()
        {
            Random random = new Random();
            
            var newOne = new RekeningViewModel();

            newOne.no_rekening = random.NextInt64(1000000000, 9999999999).ToString();
            newOne.saldo = 100000;

            newOne.PersonList = new List<RekeningPersonListViewModel>();
            var responsePerson = await personService.GetAllPersonsAsync();
            var responseBank = await bankService.GetAllBanksAsync();

            if(responsePerson != null && responsePerson.IsSuccess)
            {
                newOne.PersonList = JsonConvert.DeserializeObject<List<PersonViewModel>>(Convert.ToString(responsePerson.Result)).Select(x => new RekeningPersonListViewModel() {
                    Id = x.Id,
                    Name = x.name
                }).ToList();
            }

            if(responseBank != null && responseBank.IsSuccess)
            {
                newOne.BankList = JsonConvert.DeserializeObject<List<BankViewModel>>(Convert.ToString(responseBank.Result)).Select(x => new RekeningBankListViewModel()
                {
                    Code = x.BankCode,
                    Name = x.BankName
                }).ToList();
            }


            return View("_Add", newOne);
        }

        public async Task<IActionResult> Save(string Type, RekeningSaveViewModel data)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? res = new ResponseDto();

                if (Type == "Add")
                {
                    res = await rekeningService.CreateRekeningAsync(data);
                }
                else
                {
                    res = await rekeningService.UpdateRekeningAsync(data);
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

        public async Task<IActionResult> Update(string norek)
        {
            ResponseDto? res = await rekeningService.GetRekeningByNorekAsync(norek);
            if (res != null && res.IsSuccess)
            {
                RekeningViewModel rekening = JsonConvert.DeserializeObject<RekeningViewModel>(Convert.ToString(res.Result));

                var responsePerson = await personService.GetAllPersonsAsync();
                var responseBank = await bankService.GetAllBanksAsync();

                if (responsePerson != null && responsePerson.IsSuccess)
                {
                    rekening.PersonList = JsonConvert.DeserializeObject<List<PersonViewModel>>(Convert.ToString(responsePerson.Result)).Select(x => new RekeningPersonListViewModel()
                    {
                        Id = x.Id,
                        Name = x.name
                    }).ToList();
                }

                if (responseBank != null && responseBank.IsSuccess)
                {
                    rekening.BankList = JsonConvert.DeserializeObject<List<BankViewModel>>(Convert.ToString(responseBank.Result)).Select(x => new RekeningBankListViewModel()
                    {
                        Code = x.BankCode,
                        Name = x.BankName
                    }).ToList();
                }


                return View("_Edit", rekening);
            }
            else
            {
                TempData["Error"] = res.Message;
            }

            return NotFound();
        }

        public async Task<IActionResult> Delete(string norek)
        {
            ResponseDto? res = await rekeningService.DeleteRekeningAsync(norek);
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
