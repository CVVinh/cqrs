namespace cqrs_vhec.Request.DTOs
{
    public class UpdateProductPgDTO : CreateProductPgDTO
    {
        public int Id { get; set; }
        public UpdateProductPgDTO()
        {

        }

        public UpdateProductPgDTO(int Id, CreateProductPgDTO createProductPgDTO) : base(createProductPgDTO.Name, createProductPgDTO.Description, createProductPgDTO.Quantity, createProductPgDTO.Price, createProductPgDTO.TypeProductPgId, createProductPgDTO.ProductImage) 
        { 
            this.Id = Id;
        }

    }
}
