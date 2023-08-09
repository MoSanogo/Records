using MediatR;
using Records.Data.Dtos;

namespace Records.Mediatr.Commands
{
    public record UpdateCommand(string Id, CatUpdateDto Data) : IRequest<bool>;

}
