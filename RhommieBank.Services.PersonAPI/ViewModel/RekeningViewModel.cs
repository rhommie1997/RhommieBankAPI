using System.ComponentModel.DataAnnotations.Schema;

namespace RhommieBank.Services.PersonAPI.ViewModel
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
        public string? no_rekening { get; set; }
        public int person_id { get; set; }
        public string? person_name { get; set; }
        public decimal saldo { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public bool isAccess { get; set; }
    }
}
