using System.ComponentModel.DataAnnotations;

namespace RhommieBank.Services.PersonAPI.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string created_by { get; set; }
        public DateTime created_dt { get; set; }

        // Properti navigasi untuk mengakses koleksi Rekening yang terkait
        public ICollection<Rekening> Rekenings { get; set; }
    }
}
