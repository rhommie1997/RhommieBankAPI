using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RhommieBank.Services.MasterAPI.Models
{
    [Table("TransactionNote")]
    public class TransactionNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string username { get; set; }
        [ForeignKey("RekeningTransferFrom")]
        public string rekeningTransferFrom { get; set; }
        [ForeignKey("RekeningTransferTo")]
        public string rekeningTransferTo { get; set; }
        public string transactionName { get; set; }
        [ForeignKey("TransactionType")]
        public int transactionTypeID { get; set; }
        public decimal amount { get; set; }
        public string? description { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_dt { get; set; }
        public decimal totalAmount { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        public virtual Rekening TransferFrom { get; set; }
        public virtual Rekening TransferTo { get; set; }

    }
}
