namespace ProductApp.Data.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public Guid SizeScaleId { get; set; }

        public DateTime CreateDate { get; set; }

        public String CreatedBy { get; set; }

        public int ChannelId { get; set; }

        public List<ArticleVM>? Articles { get; set; }

        public List<Size>? Sizes { get; set; }
    }

    public class ArticleVM
    {
        public Guid ArticleId { get; set; }

        public string ArticleName { get; set; }

        public Guid ColourId { get; set; }

        public string ColourCode { get; set; }

        public string ColourName { get; set; }
    }

    public class Size
    {
        public Guid SizeId { get; set; }

        public string SizeName { get; set; }
    }
}
