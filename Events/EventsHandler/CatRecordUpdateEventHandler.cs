using AutoMapper.Configuration.Annotations;
using MediatR;
using Records.Data.Entities;
using Records.Data.Repository;

namespace Records.Events.EventsHandler
{
    public class CatRecordUpdateEventHandler : INotificationHandler<CatRecordUpdateEvent>
    {
        public readonly ICatRepository _catRepository;

        public CatRecordUpdateEventHandler(ICatRepository catRepository) =>_catRepository =catRepository;
        public Task Handle(CatRecordUpdateEvent notification, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return Task.FromCanceled(cancellationToken);
            Console.WriteLine("Handling Update event");
            var candidate = _catRepository.Get<Cat>(notification.CatId);
            if (candidate is null) { return Task.CompletedTask; }
            candidate.UpdatedAt = DateTime.Now;
            _catRepository.Update<Cat>(candidate.Id.ToString(), candidate);
            return Task.CompletedTask;
        }
    }
}
