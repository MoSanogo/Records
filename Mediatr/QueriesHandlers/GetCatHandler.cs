using AutoMapper;
using MediatR;
using Records.Data.Dtos;
using Records.Data.Repository;
using Records.Mediatr.Queries;

namespace Records.Mediatr.QueriesHandlers
{
    public class GetCatHandler : IRequestHandler<GetCatQueryById, CatDto>
    {

        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public GetCatHandler(ICatRepository catRepository, IMapper mapper)
        {
            _catRepository = catRepository ?? throw new ArgumentNullException(nameof(catRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CatDto> Handle(GetCatQueryById request, CancellationToken cancellationToken)
        {
            if(cancellationToken.IsCancellationRequested)
            {
                await Task.FromCanceled(cancellationToken);
            }

            var result = _catRepository.Get<CatDto>(request.CatId);
            return result;
        }
    }
}
