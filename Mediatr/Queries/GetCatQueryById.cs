using MediatR;
using Records.Data.Dtos;
namespace Records.Mediatr.Queries
{
    public record GetCatQueryById(string CatId) : IRequest<CatDto>;
}
