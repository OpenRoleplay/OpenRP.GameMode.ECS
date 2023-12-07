using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenRP.GameMode.Data.Models
{
    public class Character
    {
        public ulong Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(35)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(30)]
        public string Accent { get; set; }
        public Inventory Inventory { get; set; }
        public int Skin { get; set; } = 26;
    }
}
