using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhommieBank.Services.MasterAPI.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string created_by { get; set; }
        public DateTime created_dt { get; set; }

        // Properti navigasi untuk mengakses koleksi Rekening yang terkait
        public ICollection<Rekening> Rekenings { get; set; }
    }
}
