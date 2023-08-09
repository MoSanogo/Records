using MediatR;

namespace Records.Events
{
    public record CatRecordAddEvent(string CatId) : INotification;
}
