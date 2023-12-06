using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RhommieBank.Services.MasterAPI.Models;

namespace RhommieBank.Services.MasterAPI.Models
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
        public bool isDefault { get; set; }

        // 
        public virtual Person Person { get; set; }
        public virtual Bank Bank { get; set; }

        [InverseProperty("TransferFrom")]
        public virtual ICollection<TransactionNote> TransactionsFrom { get; set; }

        [InverseProperty("TransferTo")]
        public virtual ICollection<TransactionNote> TransactionsTo { get; set; }



    }
}
