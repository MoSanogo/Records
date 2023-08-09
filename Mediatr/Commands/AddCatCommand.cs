using MediatR;
using Records.Data.Dtos;

namespace Records.Mediatr.Commands
{
    public record AddCatCommand(CatAddDto Cat):IRequest<CatDto>;
   
}
