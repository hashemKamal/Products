using System.ComponentModel.DataAnnotations;

namespace ProductsCRUD.Data.Models
{
    public class ProductCRUD
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
    }
}
