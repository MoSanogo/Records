using MediatR;
using Records.Data.Entities;
using Records.Data.Repository;

namespace Records.Events.EventsHandler
{
    public class CatRecordAddEventHandler : INotificationHandler<CatRecordAddEvent>
    {
        public readonly ICatRepository _catRepository;

        public CatRecordAddEventHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository ?? throw new ArgumentNullException(nameof(catRepository));
        }

        public Task Handle(CatRecordAddEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            Console.WriteLine("Handling cat record added event");
            var candidate = _catRepository.Get<Cat>(notification.CatId);
            if (candidate is null) { return Task.CompletedTask; }
            candidate.CreatedAt= DateTime.Now;
            _catRepository.Update<Cat>(candidate.Id.ToString(), candidate);
            return Task.CompletedTask;
        }
    }
}
