﻿#pragma checksum "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "969909a1607f2fcdeab046f2a6f9ece1a5e28817318b35ef1299705b1e67b3c2"
// <auto-generated/>
#pragma warning disable 1591
namespace Test.App.Client.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using System.Diagnostics.CodeAnalysis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using static Microsoft.AspNetCore.Components.Web.RenderMode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using TimeWarp.Features.ActionTracking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using TimeWarp.Features.Developer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Features.Base.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Features.CloneTest.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Features.Color.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Features.Counter.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Features.EventStream.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\_Imports.razor"
using Test.App.Client.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor"
           [Route(Route)]

#line default
#line hidden
#nullable disable
    [global::Test.App.Client.Pages.EventStreamPage.__PrivateComponentRenderModeAttribute]
    public partial class EventStreamPage : BaseComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Web.PageTitle>(0);
            __builder.AddAttribute(1, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
#nullable restore
#line (5,13)-(5,18) 25 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor"
__builder2.AddContent(2, Title);

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n");
            __builder.OpenElement(4, "h3");
#nullable restore
#line (6,6)-(6,11) 24 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor"
__builder.AddContent(5, Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line (7,2)-(7,19) 24 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor"
__builder.AddContent(7, RenderModeDisplay);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "\r\n<hr>\r\n\r\n\r\n");
            __builder.AddMarkupContent(9, "<p>EventStream is an example of middleware. It adds each action to the event list. Displayed below</p>\r\n\r\n");
            __builder.OpenComponent<global::Test.App.Client.Features.EventStream.Components.EventStream>(10);
            __builder.AddComponentParameter(11, "TestId", "eventLists");
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n\r\n");
            __builder.OpenComponent<global::Test.App.Client.Features.Counter.Components.Counter>(13);
            __builder.AddComponentParameter(14, "TestId", "increaseCounterButton");
            __builder.CloseComponent();
            __builder.AddMarkupContent(15, "\r\n\r\n<hr>\r\n\r\n");
            __builder.AddMarkupContent(16, "<p><strong>Act:</strong>Click the `Increment CounterState.Count` Button</p>\r\n\r\n\r\n");
            __builder.AddMarkupContent(17, "<p><strong>Assert:</strong>\r\n  Confirm that the `Events` List adds a Start and Completed event for the `CounterState+IncrementCount+Action`.\r\n</p>\r\n\r\n<hr>\r\n");
            __builder.AddMarkupContent(18, "<p><strong>Repeat</strong> the above steps where `Current Render Mode` is Server and Wasm.\r\n</p>");
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor"
 
  /// <summary>
  /// The title of the page
  /// </summary>
  public const string Title = "Event Stream Page";
  
  
  /// <summary>
  /// The route for the page
  /// </summary>
  public const string Route = "/eventstream";

#line default
#line hidden
#nullable disable
        private sealed class __PrivateComponentRenderModeAttribute : global::Microsoft.AspNetCore.Components.RenderModeAttribute
        {
            private static global::Microsoft.AspNetCore.Components.IComponentRenderMode ModeImpl => 
#nullable restore
#line 1 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Pages\EventStreamPage.razor"
            InteractiveAuto

#line default
#line hidden
#nullable disable
            ;
            public override global::Microsoft.AspNetCore.Components.IComponentRenderMode Mode => ModeImpl;
        }
    }
}
#pragma warning restore 1591
