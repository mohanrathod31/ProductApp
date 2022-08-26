using System.ComponentModel.DataAnnotations;

namespace ProductApp.Data.Models
{
    public class SizeScale
    {
        [Key]
        public Guid SizeId { get; set; }

        public string SizeName { get; set; }
    }
}
