using cqrs_vhec.Module.Postgre.Entities;

namespace cqrs_vhec.Request.DTOs
{
    public class CreateProductPgDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int TypeProductPgId { get; set; }
        public ICollection<IFormFile>? ProductImage { get; set; }

        public CreateProductPgDTO() : base()
        {
        }

        public CreateProductPgDTO(string Name, string? Description, int Quantity, int Price, int TypeProductPgId, ICollection<IFormFile>? ProductImage)
        {
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
            this.Price = Price;
            this.TypeProductPgId = TypeProductPgId;
            this.ProductImage = ProductImage;
        }
    }
}
