using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;
using RhommieBank.Web.ViewModels;

namespace RhommieBank.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            List<PersonViewModel>? listPerson = new ();

            ResponseDto? response = await personService.GetAllPersonsAsync();
            if (response != null && response.IsSuccess)
            {
                listPerson = JsonConvert.DeserializeObject<List<PersonViewModel>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["Error"] = response.Message;
            }

            return View(listPerson);
        }

        public async Task<IActionResult> Add()
        {
            return View("_Add");
        }

        public async Task<IActionResult> Save(string Type,PersonAddViewModel data,PersonUpdateViewModel dataUpdate)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? res = new ResponseDto();

                if (Type == "Add")
                {
                    res = await personService.CreatePersonAsync(data);
                }
                else
                {
                    res = await personService.UpdatePersonAsync(dataUpdate);
                }

                if(res != null && res.IsSuccess)
                {
                    if(Type == "Add")
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

        public async Task<IActionResult> Update(int id)
        {
            ResponseDto? res = await personService.GetPersonByIDAsync(id);
            if(res != null && res.IsSuccess)
            {
                PersonViewModel person = JsonConvert.DeserializeObject<PersonViewModel>(Convert.ToString(res.Result));

                return View("_Edit", person);
            }
            else
            {
                TempData["Error"] = res.Message;
            }

            return NotFound();
        }


        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto? res = await personService.DeletePersonAsync(id);
            if(res != null && res.IsSuccess)
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
