namespace Test.App.Client.Features.Counter;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Test.App.Contracts.Features.ExceptionHandlings;
using Test.App.Client.Features.Base;

public partial class CounterState
{
  internal class ThrowServerSideExceptionHandler : BaseActionHandler<ThrowServerSideExceptionAction>
  {
    private readonly HttpClient HttpClient;

    public ThrowServerSideExceptionHandler(IStore store, HttpClient aHttpClient) : base(store)
    {
      HttpClient = aHttpClient;
    }

    /// <summary>
    /// Intentionally throw so we can test exception handling.
    /// </summary>
    /// <param name="aThrowServerSideExceptionAction"></param>
    /// <param name="aCancellationToken"></param>
    /// <returns></returns>
    public override async Task Handle
    (
      ThrowServerSideExceptionAction aThrowServerSideExceptionAction,
      CancellationToken aCancellationToken
    )
    {
      var throwServerSideExceptionRequest = new ThrowServerSideExceptionRequest();

      ThrowServerSideExceptionResponse throwServerSideExceptionResponse =
        await HttpClient.GetFromJsonAsync<ThrowServerSideExceptionResponse>
        (
          throwServerSideExceptionRequest.GetRoute()
          , cancellationToken: aCancellationToken
        );
    }
  }
}
