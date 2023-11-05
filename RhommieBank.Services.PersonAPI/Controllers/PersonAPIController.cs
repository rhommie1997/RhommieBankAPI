using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhommieBank.Services.PersonAPI.Data;
using RhommieBank.Services.PersonAPI.Models;
using RhommieBank.Services.PersonAPI.Models.Dto;
using RhommieBank.Services.PersonAPI.ViewModel;

namespace RhommieBank.Services.PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAPIController : ControllerBase
    {
        private readonly RhommieBankDbContext _db;
        private ResponseDto _res;
        private IMapper _mapper;
        public PersonAPIController(RhommieBankDbContext db,IMapper mapper)
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
                var objList = _db.Persons.ToList();
                _res.Result = _mapper.Map<List<PersonViewModel>>(objList);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                var obj = _db.Persons.FirstOrDefault(x => x.id == id);
                _res.Result = _mapper.Map<PersonViewModel>(obj);
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
                var objList = _db.Persons.Where(x => x.name.Contains(name)).ToList();
                _res.Result = _mapper.Map<List<PersonViewModel>>(objList);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] PersonAddViewModel pvm)
        {
            try
            {
                Person person = _mapper.Map<Person>(pvm);
                person.created_by = "System";
                person.created_dt = DateTime.Now;
                _db.Persons.Add(person);
                _db.SaveChanges();

                _res.Result = _mapper.Map<PersonViewModel>(person);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }

        [HttpPut]
        public ResponseDto Update([FromBody] PersonUpdateViewModel pvm)
        {
            try
            {
                Person person = _db.Persons.Where(x => x.id == pvm.Id).FirstOrDefault();
                if (person != null)
                {
                    person.name = pvm.name;
                    person.age = pvm.age;
                    _db.Persons.Update(person);
                    _db.SaveChanges();
                }
                else
                {
                    _res.IsSuccess = false;
                    _res.Message = "Data Not Found!";
                }
                _res.Result = _mapper.Map<PersonUpdateViewModel>(person);
            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }
            return _res;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Person person = _db.Persons.FirstOrDefault(x => x.id == id);
                if (person != null)
                {;
                    _db.Persons.Remove(person);
                    _db.SaveChanges();
                }
                else
                {
                    _res.IsSuccess = false;
                    _res.Message = "Data Not Found!";
                }
                _res.Result = _mapper.Map<PersonUpdateViewModel>(person);
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
