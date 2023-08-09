using MediatR;
using Records.Data.Repository;
using Records.Mediatr.Commands;

namespace Records.Mediatr.CommandHandlers
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {

        public readonly ICatRepository _catRepository;
        public DeleteCommandHandler(ICatRepository catRepository) => _catRepository = catRepository;
        public Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled<bool>(cancellationToken);
            if (request.Id is null) return Task.FromResult(false);
            return Task.FromResult(_catRepository.Remove(request.Id));
        }
    }
}
