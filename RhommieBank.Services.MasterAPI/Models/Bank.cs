using RhommieBank.Services.MasterAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhommieBank.Services.MasterAPI.Models
{
    [Table("Bank")]
    public class Bank
    {
        [Key]
        public string BankCode { get; set; }
        public string BankName { get; set; }
        [ForeignKey("Currency")]
        public string CurrencyCode { get; set; }
        public ICollection<Rekening> Rekenings { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
