using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public int? CategoryID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Quantity{ get; set; }

        [Required]
        public double? Price{ get; set; }

        public Category Category { get; set; }
    }
}
