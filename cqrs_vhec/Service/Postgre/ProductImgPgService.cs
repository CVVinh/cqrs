using cqrs_vhec.Data;
using cqrs_vhec.Module.Postgre.Entities;

namespace cqrs_vhec.Service.Postgre
{
    public interface IProductImgPgService : IPostgreRepo<ProductImgPg>
    {

    }

    public class ProductImgPgService : PostgreRepo<ProductImgPg>, IProductImgPgService
    {
        private readonly PostgreDBContext _dbContext;

        public ProductImgPgService(PostgreDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
