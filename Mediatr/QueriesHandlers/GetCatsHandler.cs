using AutoMapper;
using MediatR;
using Records.Data.Dtos;
using Records.Data.Repository;
using Records.Mediatr.Queries;
using System.Collections;

namespace Records.Mediatr.QueriesHandlers
{
    public class GetCatsHandler : IRequestHandler<GetCatsQuery,IEnumerable<CatDto>>
    {

        private readonly ICatRepository _catRepository;
        private readonly  IMapper _mapper;

        public GetCatsHandler(ICatRepository catRepository,IMapper mapper)
        {
            _catRepository = catRepository ?? throw new ArgumentNullException(nameof(catRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CatDto>> Handle(GetCatsQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                await Task.FromCanceled(cancellationToken);

            }
            return _catRepository.GetAll<CatDto>();
        }
    }
}
