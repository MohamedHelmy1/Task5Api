using System.ComponentModel.DataAnnotations.Schema;
using Task4Api.Model;

namespace Task4Api.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int amount { get; set; }
       
        public int CatalogId { get; set; }
        public String? CatalogName { get; set; }
    }
}
