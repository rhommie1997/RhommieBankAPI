using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhommieBank.Services.MasterAPI.Models
{
    [Table("Currency")]
    public class Currency
    {
        [Key]
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Bank> Banks { get; set; }
    }
}
