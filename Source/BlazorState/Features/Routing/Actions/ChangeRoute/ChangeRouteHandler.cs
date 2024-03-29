namespace TimeWarp.Features.Routing;

public partial class RouteState
{
  internal class ChangeRouteHandler
  (
    IStore store,
    NavigationManager NavigationManager,
    ILogger<ChangeRouteHandler> logger
  ) : ActionHandler<ChangeRoute.Action>(store)
  {
    private readonly ILogger Logger = logger;

    private RouteState RouteState => Store.GetState<RouteState>();

    public override Task Handle(ChangeRoute.Action action, CancellationToken cancellationToken)
    {
      Logger.LogDebug("ChangeRouteAction.Handle-NewRoute:{NewRoute}", action.NewRoute);
      string newAbsoluteUri = NavigationManager.ToAbsoluteUri(action.NewRoute).ToString();
      string absoluteUri = NavigationManager.Uri;

      if (absoluteUri != newAbsoluteUri)
      {
        // TimeWarpNavigationManager OnLocationChanged will fire this ChangeRouteRequest again
        // and the second time we will hit the `else` clause.
        NavigationManager.NavigateTo(newAbsoluteUri);
      }
      else if (RouteState.Route != newAbsoluteUri)
      {
        if(!RouteState.GoingBack)
          RouteState.HistoryStack.Push(RouteState.Route);
        else
        {
          RouteState.GoingBack = false;
        }
        RouteState.Route = newAbsoluteUri;
      }
      return Task.CompletedTask;
    }
  }
}
