using AutoMapper;
using RhommieBank.Services.PersonAPI.Models;
using RhommieBank.Services.PersonAPI.ViewModel;

namespace RhommieBank.Services.PersonAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapConfig = new MapperConfiguration(x => {
                x.CreateMap<PersonViewModel, Person>();
                x.CreateMap<Person, PersonViewModel>();
                x.CreateMap<PersonAddViewModel, Person>();
                x.CreateMap<Person, PersonAddViewModel>();
                x.CreateMap<PersonUpdateViewModel, Person>();
                x.CreateMap<Person, PersonUpdateViewModel>();

                x.CreateMap<Bank, BankViewModel>();
                x.CreateMap<BankViewModel, Bank>();


                //RekeningSaveViewModel
                x.CreateMap<Rekening, RekeningViewModel>();
                x.CreateMap<RekeningViewModel, Rekening>();
                x.CreateMap<Rekening, RekeningSaveViewModel>();
                x.CreateMap<RekeningSaveViewModel, Rekening>();
            });

            return mapConfig;
        }

    }
}
