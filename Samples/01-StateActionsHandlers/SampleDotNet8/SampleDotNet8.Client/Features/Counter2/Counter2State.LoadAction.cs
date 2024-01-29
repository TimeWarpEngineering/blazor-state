namespace SampleDotNet8.Client.Features.Counter2;

using BlazorState.Features.Persistence.Abstractions;
using BlazorState.Features.Persistence.Attributes;
using BlazorState.Services;
using System.Diagnostics.CodeAnalysis;

public partial class Counter2State
{
  public static class Load
  {
    
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Instantiated by BlazorState")]
    public class Action : IAction { }

    public class Handler(IStore store,
      IPersistenceService PersistenceService,
      RenderPhaseService RenderPhaseService
    ) : ActionHandler<Action>(store)
    {
      Counter2State Counter2State => Store.GetState<Counter2State>();
      
      public override async Task Handle(Action aAction, CancellationToken aCancellationToken)
      {
        Console.WriteLine("Entering Counter2State.Load.Handler: Counter2State.Count: {0} Counter2State.Guid {1} ", Counter2State.Count, Counter2State.Guid);
        Console.WriteLine("Counter2State RenderPhaseService.Guid: {0}, IsPreRendering{1}", RenderPhaseService.Guid, RenderPhaseService.IsPreRendering );
        
        if (RenderPhaseService.IsPreRendering)
        {
          Console.WriteLine("Skipping Load as we are prerendering");
          return;
        }
        Console.WriteLine("Counter2State.Load.Handler: Loading Counter2State");
        
        
        object? state = await PersistenceService.LoadState(typeof(Counter2State), PersistentStateMethod.LocalStorage);
        if (state is Counter2State counter2State)
        {
          Console.WriteLine("Loaded Counter2State.Load.Handler: Counter2State.Count: {0} Counter2State.Guid {1}", counter2State.Count, counter2State.Guid);
          Store.SetState(counter2State);
          Console.WriteLine("Loaded Counter2State.Load.Handler: Counter2State.Count: {0} Counter2State.Guid {1}", Counter2State.Count, Counter2State.Guid);
        }
      }
    }
  }
}