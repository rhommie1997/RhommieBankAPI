using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhommieBank.Services.MasterAPI.Models;
using RhommieBank.Services.PersonAPI.Data;
using RhommieBank.Services.PersonAPI.Models.Dto;
using RhommieBank.Services.PersonAPI.ViewModel;

namespace RhommieBank.Services.PersonAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BankAPIController : Controller
    {
        private readonly RhommieBankDbContext _db;
        private ResponseDto _res;
        private IMapper _mapper;

        public BankAPIController(RhommieBankDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _res = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                var objList = _db.Banks.ToList();
                _res.Result = _mapper.Map<List<BankViewModel>>(objList);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpGet]
        [Route("{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                var obj = _db.Banks.FirstOrDefault(x => x.BankCode == code);
                _res.Result = _mapper.Map<BankViewModel>(obj);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }
            return _res;
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDto GetByName(string name)
        {
            try
            {
                var objList = _db.Banks.Where(x => x.BankName.Contains(name)).ToList();
                _res.Result = _mapper.Map<List<BankViewModel>>(objList);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] BankViewModel bvm)
        {
            try
            {
                Bank bank = _mapper.Map<Bank>(bvm);
                _db.Banks.Add(bank);
                _db.SaveChanges();

                _res.Result = _mapper.Map<BankViewModel>(bank);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpPut]
        public ResponseDto Update([FromBody] BankViewModel bvm)
        {
            try
            {
                Bank bank = _db.Banks.Where(x => x.BankCode == bvm.BankCode).FirstOrDefault();
                if (bank != null)
                {
                    bank.BankCode = bvm.BankCode;
                    bank.BankName = bvm.BankName;
                    _db.Banks.Update(bank);
                    _db.SaveChanges();
                }
                else
                {
                    _res.IsSuccess = false;
                    _res.Message = "Data Not Found!";
                }
                _res.Result = _mapper.Map<BankViewModel>(bank);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }
            return _res;
        }

        [HttpDelete]
        public ResponseDto Delete(string BankCode)
        {
            try
            {
                Bank bank = _db.Banks.FirstOrDefault(x => x.BankCode == BankCode);
                if (bank != null)
                {
                    ;
                    _db.Banks.Remove(bank);
                    _db.SaveChanges();
                }
                else
                {
                    _res.IsSuccess = false;
                    _res.Message = "Data Not Found!";
                }
                _res.Result = _mapper.Map<BankViewModel>(bank);
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
