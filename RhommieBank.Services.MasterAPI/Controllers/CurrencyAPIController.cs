using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhommieBank.Services.MasterAPI.Data;
using RhommieBank.Services.MasterAPI.Models.Dto;
using RhommieBank.Services.MasterAPI.ViewModel;

namespace RhommieBank.Services.MasterAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyAPIController : ControllerBase
    {

        private readonly RhommieBankDbContext _db;
        private ResponseDto _res;

        public CurrencyAPIController(RhommieBankDbContext db, IMapper mapper)
        {
            _db = db;
            _res = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                var objList = _db.Currencies.Select(x => new CurrencyViewModel()
                {
                    CurrencyCode = x.CurrencyCode,
                    CurrencyName = x.CurrencyName,
                    Country = x.Country
                }).ToList();
                _res.Result = objList;
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }


    }
}
