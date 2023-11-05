using RhommieBank.Web.Models;
using RhommieBank.Web.Service.Abstract;

namespace RhommieBank.Web.ViewModels
{

    public class RekeningSaveViewModel
    {
        public string? no_rekening { get; set; }
        public int person_id { get; set; }
        public decimal saldo { get; set; }
        public string BankCode { get; set; }
        public bool isAccess { get; set; }
    }

    public class RekeningViewModel
    {
        private readonly IPersonService personService;
        public RekeningViewModel()
        {
            
        }
        public RekeningViewModel(IPersonService _ps)
        {
            personService = _ps;

        }


        public string? no_rekening { get; set; }
        public int person_id { get; set; }
        public string? person_name { get; set; }
        public decimal saldo { get; set; }
        public string BankCode { get; set; }
        public string? BankName { get; set; }
        public bool isAccess { get; set; }
        public List<RekeningPersonListViewModel> PersonList { get; set; }
        public List<RekeningBankListViewModel> BankList { get; set; }

    }

    public class RekeningPersonListViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class RekeningBankListViewModel
    {
        public string Code { get; set; }
        public string? Name { get; set; }
    }

}


