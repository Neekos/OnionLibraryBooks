using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fam { get; set; }
        public byte[]? Avatar {get; set;}
        public DateTime DateBirthday {get; set;}
        public DateTime DateRegistration { get; set;}
    }
}
