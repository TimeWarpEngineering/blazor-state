namespace Test.App.Client.Features.EventStream;

using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Test.App.Contracts.Features.Base;
using static Test.App.Client.Features.EventStream.EventStreamState;

/// <summary>
/// Every event that comes through the pipeline adds an object to the EventStreamState
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
/// <remarks>To avoid infinite recursion don't add AddEvent to the event stream</remarks>
public class EventStreamBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : notnull
{
  private readonly ILogger Logger;
  private readonly ISender Sender;
  public Guid Guid { get; } = Guid.NewGuid();

  public EventStreamBehavior
  (
    ILogger<EventStreamBehavior<TRequest, TResponse>> aLogger,
    ISender aSender
  )
  {
    Logger = aLogger;
    Sender = aSender;
    Logger.LogDebug("{classname}: Constructor", GetType().Name);
  }

  public async Task<TResponse> Handle
  (
    TRequest aRequest,
    RequestHandlerDelegate<TResponse> aNext,
    CancellationToken aCancellationToken
  )
  {
    if (aNext is null)
    {
      throw new ArgumentNullException(nameof(aNext));
    }
    await AddEventToStream(aRequest, "Start");
    TResponse response = await aNext();
    await AddEventToStream(aRequest, "Completed");
    return response;
  }

  private async Task AddEventToStream(TRequest aRequest, string aTag)
  {
    if (!(aRequest is AddEventAction)) //Skip to avoid recursion
    {
      var addEventAction = new AddEventAction();
      string requestTypeName = aRequest.GetType().Name;

      if (aRequest is BaseRequest request)
      {
        addEventAction.Message = $"{aTag}:{requestTypeName}:{request.CorrelationId}";
      }
      else
      {
        addEventAction.Message = $"{aTag}:{requestTypeName}";
      }
      await Sender.Send(addEventAction);
    }
  }
}
