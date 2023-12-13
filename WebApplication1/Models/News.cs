using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class News
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        [StringLength(1000)]
        public string? Content { get; set; }
        public string? Image { get; set; }
        
        public string Image2 { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }

    }
}
