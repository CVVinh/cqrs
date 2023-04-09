using cqrs_vhec.Data;
using cqrs_vhec.Module.Mongo.EntitiesMg;
using cqrs_vhec.Service.Mongo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml;

namespace cqrs_vhec.Service
{
    public interface IDataSynchronizationService<TEntityPg, TEntityMg> 
        where TEntityPg : class 
        where TEntityMg : class
    {
        Task SynchronizeAsync(Expression<Func<TEntityMg, bool>> expression);
    }

    public class DataSynchronizationService<TEntityPg, TEntityMg> : IDataSynchronizationService<TEntityPg, TEntityMg>
        where TEntityPg : class
        where TEntityMg : class
    {
        private readonly PostgreRepo<TEntityPg> _postgreRepo;
        private readonly MongoRepo<TEntityMg> _mongoRepo;

        public DataSynchronizationService(PostgreRepo<TEntityPg> postgreRepo, MongoRepo<TEntityMg> mongoRepo)
        {
            _postgreRepo = postgreRepo;
            _mongoRepo = mongoRepo;
        }

        public async Task SynchronizeAsync(Expression<Func<TEntityMg, bool>> expression)
        {
            // Lấy danh sách các entity từ Postgre
            var entities = await _postgreRepo.GetAll();

            // Đồng bộ dữ liệu từ Postgre sang MongoDB
            foreach (var entity in entities)
            {
                var existingEntity = await _mongoRepo.GetByIdByFun(expression);

                if (existingEntity == null)
                {
                    // Nếu entity chưa có trong MongoDB thì tạo mới
                    await _mongoRepo.AddAsync(entity);
                }
                else
                {
                    // Nếu entity đã có trong MongoDB thì cập nhật thông tin
                    //existingEntity.Name = entity.Name;
                    //existingEntity.Description = entity.Description;

                    //existingEntity = entity;
                    await _mongoRepo.UpdateByFun(existingEntity, expression);
                }
            }
        }
    }

}
