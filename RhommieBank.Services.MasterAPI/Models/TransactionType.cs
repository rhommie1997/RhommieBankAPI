using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RhommieBank.Services.MasterAPI.Models
{
    [Table("TransactionType")]
    public class TransactionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string TransactionTypeName { get; set; }
        public decimal Charges { get; set; }

        public virtual ICollection<TransactionNote> TransactionNotes { get; set; }
    }
}
