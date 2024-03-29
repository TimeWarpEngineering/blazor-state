namespace Test.App.Client.Features.Application;

using static RouteState;
using static ApplicationState;

[UsedImplicitly]
internal class ResetStoreHandler
(
  IStore Store,
  ISender Sender
) : IRequestHandler<ResetStoreAction>
{
  public async Task Handle(ResetStoreAction resetStoreAction, CancellationToken cancellationToken)
  {
    Store.Reset();
    await Sender.Send(new ChangeRoute.Action { NewRoute = "/" }, cancellationToken);
  }
}
