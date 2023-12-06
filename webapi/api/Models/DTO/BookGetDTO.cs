// classe modele data transfer object (DTO) pour la methode get 
namespace BookService.Models
{
    public class BookGetDTO // on retire l'id et le prix car on ne veut pas les voir 
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
    }
}
