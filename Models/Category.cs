using System.Collections.Generic;

namespace ProductsApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
