using System.ComponentModel.DataAnnotations.Schema;

namespace Task4Api.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float  Price { get; set; }
        public int amount { get; set; }
        [ForeignKey("Catalog")]
        public int CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
    }
}
