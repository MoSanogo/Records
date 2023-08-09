using MediatR;

namespace Records.Events
{
    public record CatRecordUpdateEvent(string CatId):INotification;
  
}
