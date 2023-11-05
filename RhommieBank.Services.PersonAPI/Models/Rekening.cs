using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RhommieBank.Services.PersonAPI.Models
{

    [Table("Rekening")]
    public class Rekening
    {
        [Key]
        public string? no_rekening { get; set; }


        [ForeignKey("Person")]
        public int person_id { get; set; }
        public decimal saldo { get; set; }


        [ForeignKey("Bank")]
        public string BankCode { get; set; }
        public bool isAccess { get; set; }
        public DateTime created_dt { get; set; }

        // 
        public virtual Person Person { get; set; }
        public virtual Bank Bank { get; set; }


    }
}
