using System.ComponentModel.DataAnnotations;

namespace RhommieBank.Services.PersonAPI.Models
{
    public class User
    {
        [Key]
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? nickname { get; set; }
        public bool isAdmin { get; set; }
        public string? imagePath { get; set; }
    }
}
