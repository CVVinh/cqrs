using cqrs_vhec.Data;
using cqrs_vhec.Module.Postgre.Entities;

namespace cqrs_vhec.Service.Postgre
{
    public interface IInformationTypeProductPgService : IPostgreRepo<InformationTypeProductPg>
    {

    }

    public class InformationTypeProductPgService : PostgreRepo<InformationTypeProductPg>, IInformationTypeProductPgService
    {
        private readonly PostgreDBContext _dbContext;

        public InformationTypeProductPgService(PostgreDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }


}
