using MediatR;
using Records.Data.Dtos;

namespace Records.Mediatr.Queries
{
    public record GetCatsQuery() : IRequest<IEnumerable<CatDto>>;

}
