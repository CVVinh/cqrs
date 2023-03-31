using System.ComponentModel.DataAnnotations;

namespace cqrs_vhec.Module.Postgre
{
    public class ProductPg
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
