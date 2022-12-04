using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenRP.GameMode.Data.Models
{
    public class Character
    {
        public ulong Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(35)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string MiddleName { get; set; }
        [Required]
        [Column(TypeName = "varchar(35)")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Accent { get; set; }
        public Inventory Inventory { get; set; }
    }
}
