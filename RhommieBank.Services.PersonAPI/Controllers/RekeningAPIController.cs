using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RhommieBank.Services.PersonAPI.Data;
using RhommieBank.Services.PersonAPI.Models;
using RhommieBank.Services.PersonAPI.Models.Dto;
using RhommieBank.Services.PersonAPI.ViewModel;

namespace RhommieBank.Services.PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RekeningAPIController : Controller
    {

        private readonly RhommieBankDbContext _db;
        private ResponseDto _res;
        private IMapper _mapper;

        public RekeningAPIController(RhommieBankDbContext db, IMapper mapper)
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
                var objList = _db.Rekenings.Select(
                    x => new RekeningViewModel() { 
                        no_rekening = x.no_rekening,
                        person_id = x.person_id,
                        person_name = x.Person.name,
                        BankCode= x.BankCode,
                        BankName = x.Bank.BankName,
                        isAccess = x.isAccess,
                        saldo = x.saldo 
                    }
                ).ToList();


                _res.Result = objList;
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpGet]
        [Route("{norek}")]
        public ResponseDto Get(string norek)
        {
            try
            {
                var obj = _db.Rekenings.Select(
                    x => new RekeningViewModel()
                    {
                        no_rekening = x.no_rekening,
                        person_id = x.person_id,
                        person_name = x.Person.name,
                        BankCode = x.BankCode,
                        BankName = x.Bank.BankName,
                        isAccess = x.isAccess,
                        saldo = x.saldo
                    }
                ).FirstOrDefault();
                _res.Result = obj;
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }
            return _res;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] RekeningSaveViewModel rvm)
        {
            try
            {
                Rekening rek = _mapper.Map<Rekening>(rvm);
                _db.Rekenings.Add(rek);
                _db.SaveChanges();

                _res.Result = _mapper.Map<RekeningSaveViewModel>(rek);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpPut]
        public ResponseDto Update([FromBody] RekeningSaveViewModel rvm)
        {
            try
            {
                Rekening rek = _db.Rekenings.Where(x => x.no_rekening == rvm.no_rekening).FirstOrDefault();
                if (rek != null)
                {
                    rek.person_id = rvm.person_id;
                    rek.saldo = rvm.saldo;
                    rek.BankCode = rvm.BankCode ?? "014";
                    rek.isAccess = rvm.isAccess;
                    rek.created_dt = DateTime.Now;
                    _db.Rekenings.Update(rek);
                    _db.SaveChanges();
                }
                else
                {
                    _res.IsSuccess = false;
                    _res.Message = "Data Not Found!";
                }
                _res.Result = _mapper.Map<RekeningViewModel>(rek);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }
            return _res;
        }

        [HttpDelete]
        public ResponseDto Delete(string norek)
        {
            try
            {
                Rekening rek = _db.Rekenings.FirstOrDefault(x => x.no_rekening == norek);
                if (rek != null)
                {
                    ;
                    _db.Rekenings.Remove(rek);
                    _db.SaveChanges();
                }
                else
                {
                    _res.IsSuccess = false;
                    _res.Message = "Data Not Found!";
                }
                _res.Result = _mapper.Map<RekeningViewModel>(rek);
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
