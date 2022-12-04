using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenRP.GameMode.Data.Models
{
    public class Account
    {
        public ulong Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(24)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "char(60)")]
        public string Password { get; set; }
        public byte Level { get; set; }
        public ushort Experience { get; set; }
        public List<Character> Characters { get; set; }

        public Account()
        {
            Characters = new List<Character>();
        }
    }
}
