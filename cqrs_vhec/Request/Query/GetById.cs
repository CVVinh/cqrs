using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.DTOs;
using MediatR;

namespace cqrs_vhec.Request.Query
{
    public class GetById<T> : IRequest<BaseResponse<T>>
    {
        public int Id { get; set; }
        public GetById(int id)
        {
            Id = id;
        }
    }
}
