namespace Test.App.Client.Features.Application;

using System.Threading;
using System.Threading.Tasks;
using static BlazorState.Features.Routing.RouteState;
using static Test.App.Client.Features.Application.ApplicationState;

internal class ResetStoreHandler : IRequestHandler<ResetStoreAction>
{
  private readonly ISender Sender;
  private readonly IStore Store;
  public ResetStoreHandler(IStore aStore, ISender aSender)
  {
    Sender = aSender;
    Store = aStore;
  }


  public async Task Handle(ResetStoreAction aResetStoreAction, CancellationToken aCancellationToken)
  {
    Store.Reset();
    await Sender.Send(new ChangeRouteAction { NewRoute = "/" }, aCancellationToken);
  }
}
