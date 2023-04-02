using AutoMapper;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_vhec.Request.Command.PostgreCM
{
    public class UpdateInformationProductPgCommand : CreateInformationProductPgCommand
    {
        public int Id { get; set; }
        
        public UpdateInformationProductPgCommand() : base()
        {
        }

        public UpdateInformationProductPgCommand(int Id, CreateInformationProductPgCommand createInformationProductPgCommand) : base(createInformationProductPgCommand)
        {
            this.Id = Id;
        }
    }

    public class UpdateInformationProductPgHandler : IRequestHandler<UpdateInformationProductPgCommand, InformationProductPg>
    {
        private readonly IInformationProductPgService _informationProductPgService;
        private readonly IMapper _mapper;

        public UpdateInformationProductPgHandler(IInformationProductPgService informationProductPgService, IMapper mapper)
        {
            _informationProductPgService = informationProductPgService;
            _mapper = mapper;
        }

        public async Task<InformationProductPg> Handle(UpdateInformationProductPgCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEntity = await _informationProductPgService.GetById(s => s.Id.Equals(request.Id), s => s.Include(s => s.InformationTypeProductPg));
                if (existingEntity == null)
                {
                    return null;
                }
                var mapData = _mapper.Map(request, existingEntity);
                await _informationProductPgService.Update(mapData);
                return mapData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
