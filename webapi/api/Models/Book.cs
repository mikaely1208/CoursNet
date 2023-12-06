namespace webapi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
// ce fichier contient la classe book et ses attributs 
public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(4)")]
    [StringLength(4)]
    public string? Title { get; set; } = null!;


    [Column(TypeName = "ntext")]
    public string? Author { get; set; }

    [Column(TypeName = "nvarchar(20)")]
    [StringLength(20)]
    public string? Genre { get; set; }

    [Column(TypeName = "decimal(18,2)")] //La précision = référence au nombre total de chiffres qu'on peut stocker dans la colonne échelle =  nombre de décimales
    public decimal Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PublishDate { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [Column(TypeName = "ntext")]
    public string? Remarks { get; set; }

}