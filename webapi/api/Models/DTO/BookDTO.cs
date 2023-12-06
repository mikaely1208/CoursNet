// classe modele data transfer object (DTO)
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace BookService.Models
{
    public class BookDTO
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
    }
}
