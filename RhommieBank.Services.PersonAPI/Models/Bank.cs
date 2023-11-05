﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhommieBank.Services.PersonAPI.Models
{
    [Table("Bank")]
    public class Bank
    {
        [Key]
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public ICollection<Rekening> Rekenings { get; set; }
    }
}
