﻿namespace TestApp.Client.Integration.Tests.Features.Counter_Tests
{
  using AnyClone;
  using BlazorState;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using System;
  using TestApp.Client.Features.Counter;
  using TestApp.Client.Integration.Tests.Infrastructure;

  internal class CounterStateCloneTests : BaseTest
  {
    public CounterStateCloneTests(ClientHost aWebAssemblyHost) : base(aWebAssemblyHost)
    {
      IServiceProvider serviceProvider = aWebAssemblyHost.ServiceProvider;
      IStore store = serviceProvider.GetService<IStore>();
      CounterState = store.GetState<CounterState>();
    }

    private CounterState CounterState { get; set; }

    public void ShouldClone()
    {
      //Arrange
      CounterState.Initialize(aCount: 15);

      //Act
      var clone = CounterState.Clone() as CounterState;

      //Assert
      CounterState.ShouldNotBeSameAs(clone);
      CounterState.Count.ShouldBe(clone.Count);
      CounterState.Guid.ShouldNotBe(clone.Guid);
    }

  }
}
