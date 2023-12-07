using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenRP.GameMode.Data.Models
{
    public class Account
    {
        public ulong Id { get; set; }
        [Required]
        [MaxLength(24)]
        public string Username { get; set; }
        [Required]
        [MaxLength(60)]
        public string Password { get; set; }
        public byte Level { get; set; } = 1;
        public ushort Experience { get; set; } = 0;
        public List<Character> Characters { get; set; }

        public Account()
        {
            Characters = new List<Character>();
        }
    }
}
