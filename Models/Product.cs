using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int CategoryCode { get; set; }

        public DateTime CreationDate { get; set; }

        [ForeignKey("CategoryCode")]
        public Category Category { get; set; }

    }
}
