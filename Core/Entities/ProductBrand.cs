using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProductBrand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}