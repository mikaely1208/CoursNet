// classe modele data transfer object (DTO)
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace BookService.Models
{
    public class BookUpdateDTO
    {
    [Required]
    [Column(TypeName = "nvarchar(4)")]
    [StringLength(4)]
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
    }
}
