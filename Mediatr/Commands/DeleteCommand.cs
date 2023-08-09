using MediatR;

namespace Records.Mediatr.Commands
{
    public record DeleteCommand(string Id):IRequest<bool>;
   
}
