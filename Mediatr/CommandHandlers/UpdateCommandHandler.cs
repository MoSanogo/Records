using MediatR;
using Records.Data.Dtos;
using Records.Data.Repository;
using Records.Mediatr.Commands;

namespace Records.Mediatr.CommandHandlers
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand,bool>
    {
        private readonly ICatRepository _catRepository;
        public UpdateCommandHandler(ICatRepository catRepository) => _catRepository = catRepository;

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            if(cancellationToken.IsCancellationRequested)return await Task.FromCanceled<bool> (cancellationToken);

            return _catRepository.Update<CatUpdateDto>(request.Id, request.Data);


        }
           

    }
}
