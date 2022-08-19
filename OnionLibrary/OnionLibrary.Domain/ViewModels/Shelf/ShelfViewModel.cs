using System;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionLibrary.Domain.ViewModels.Shelf
{
    public class ShelfViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}

