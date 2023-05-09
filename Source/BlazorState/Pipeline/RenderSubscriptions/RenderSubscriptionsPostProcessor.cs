# nullable enable

namespace BlazorState.Pipeline.RenderSubscriptions;

internal class RenderSubscriptionsPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
  where TRequest : notnull, IAction
{
  private readonly ILogger Logger;

  private readonly Subscriptions Subscriptions;

  public RenderSubscriptionsPostProcessor
  (
    ILogger<RenderSubscriptionsPostProcessor<TRequest, TResponse>> aLogger,
    Subscriptions aSubscriptions
  )
  {
    Logger = aLogger;
    Logger.LogDebug(EventIds.RenderSubscriptionsPostProcessor_Constructing, "constructing");
    Subscriptions = aSubscriptions;
  }

  public Task Process(TRequest aRequest, TResponse aResponse, CancellationToken aCancellationToken)
  {
    Type requestType = typeof(TRequest);
    Type? declaringType = requestType.DeclaringType;
    bool isDeclaringTypeAState = typeof(IState).IsAssignableFrom(declaringType);
    if (declaringType == null || !isDeclaringTypeAState)
    {
      throw new NonNestedClassException($"The Action ({requestType.FullName}) is not a nested class of its State", nameof(aRequest));
    }

    // logging variables
    string className = GetType().Name;
    className = className.Remove(className.IndexOf('`'));

    Logger.LogDebug(EventIds.RenderSubscriptionsPostProcessor_Begin, "Begin Post Processing");

    try
    {
      Subscriptions.ReRenderSubscribers(declaringType);
      Logger.LogDebug(EventIds.RenderSubscriptionsPostProcessor_End, "Post Processing Complete");
    }
    catch (Exception aException)
    {
      Logger.LogDebug
      (
        EventIds.RenderSubscriptionsPostProcessor_Exception,
        aException,
        "Error re-rendering subscriptions"
      );
      throw;
    }
    return Task.CompletedTask;
  }
}
