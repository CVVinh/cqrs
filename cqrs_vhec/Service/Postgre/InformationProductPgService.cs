using cqrs_vhec.Data;
using cqrs_vhec.Module.Postgre.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace cqrs_vhec.Service.Postgre
{
    public interface IInformationProductPgService : IPostgreRepo<InformationProductPg>
    {

    }

    public class InformationProductPgService : PostgreRepo<InformationProductPg>, IInformationProductPgService
    {
        private readonly PostgreDBContext _dbContext;

        public InformationProductPgService(PostgreDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
