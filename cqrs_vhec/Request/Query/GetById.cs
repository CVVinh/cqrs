using cqrs_vhec.Module.Postgre.Entities;
using MediatR;

namespace cqrs_vhec.Request.Query
{
    public class GetById<T> : IRequest<T>
    {
        public int Id { get; set; }
        public GetById(int id)
        {
            Id = id;
        }
    }
}
