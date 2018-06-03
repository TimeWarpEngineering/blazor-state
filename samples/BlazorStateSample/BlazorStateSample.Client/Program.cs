﻿using BlazorState;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;

namespace BlazorStateSample.Client
{
  public class Program
  {
    private static void Main(string[] args)
    {
      #region serviceProvider initialization

      var serviceProvider = new BrowserServiceProvider(services =>
      {
        services.AddBlazorState(options =>
        {
          options.UseReduxDevToolsBehavior = false; // See other demo on using ReduxDevTools
          options.UseRouting = false; // See other demo on Routing.
          options.UseCloneStateBehavior = true; // The basics.
        });
      });

      #endregion serviceProvider initialization

      new BrowserRenderer(serviceProvider).AddComponent<App>("app");
    }
  }
}