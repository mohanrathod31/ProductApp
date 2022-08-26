using System.ComponentModel.DataAnnotations;

namespace ProductApp.Data.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string? ProductCode { get; set; }

        [MaxLength(100)]
        public string? ProductName { get; set; }

        [Required]
        public int ProductYear { get; set; }

        [Required]
        public int ChannelId { get; set; }

        [Required]
        public Guid SizeScaleId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        public List<Article>? Articles { get; set; }
    }

    public class Article
    {
        public Guid ArticleId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        [Required]
        public Guid ColourId { get; set; }
    }
}
