using SampSharp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpenRP.GameMode.Data.Models
{
    public class Account
    {
        public ulong Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(24)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "char(128)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "char(10)")]
        public string Salt { get; set; }
        public byte Level { get; set; }
        public ushort Experience { get; set; }
        public List<Character> Characters { get; set; }
    }
}
