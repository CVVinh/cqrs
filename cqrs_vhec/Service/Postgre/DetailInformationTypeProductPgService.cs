using cqrs_vhec.Data;
using cqrs_vhec.Module.Postgre.Entities;

namespace cqrs_vhec.Service.Postgre
{
    public interface IDetailInformationTypeProductPgService : IPostgreRepo<DetailInformationTypeProductPg>
    {

    }

    public class DetailInformationTypeProductPgService : PostgreRepo<DetailInformationTypeProductPg>, IDetailInformationTypeProductPgService
    {
        private readonly PostgreDBContext _dbContext;

        public DetailInformationTypeProductPgService(PostgreDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
