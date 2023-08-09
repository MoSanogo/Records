using MediatR;
using Records.Data.Dtos;
using Records.Data.Repository;
using Records.Mediatr.Commands;

namespace Records.Mediatr.CommandHandlers
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, CatDto>
    {
       
        private readonly ICatRepository _catRepository;

        public AddCatCommandHandler( ICatRepository catRepository)
        {
          
            _catRepository = catRepository ?? throw new ArgumentNullException(nameof(catRepository));
        }

        public async  Task<CatDto> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {

            if (cancellationToken.IsCancellationRequested) return await Task.FromCanceled<CatDto>(cancellationToken);
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _catRepository.Insert<CatDto,CatAddDto>(request.Cat);


        }
    }
}
