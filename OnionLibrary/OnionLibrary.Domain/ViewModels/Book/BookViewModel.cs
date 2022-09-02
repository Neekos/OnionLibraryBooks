using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.Domain.ViewModels.Book
{
    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string img { get; set; }
        public int IdUser { get; set; }
        public int IdShelf { get; set; }
        public int IdCategory { get; set; }
    }
}
