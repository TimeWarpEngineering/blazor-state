﻿#pragma checksum "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15c0ffeddab25332de44a0e40d1ee30cd6f9bed04ae370d645489a927ff08c24"
// <auto-generated/>
#pragma warning disable 1591
namespace Test.App.Client.Features.Purple.Components
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
    public partial class PurpleCounter : BaseComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Counter</h3>\r\n");
#nullable restore
#line (3,2)-(3,19) 24 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
__builder.AddContent(1, RenderModeDisplay);

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
 if (IsPreRendering)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<div role=\"status\">CounterState.Guid: </div>\r\n  ");
            __builder.AddMarkupContent(3, "<div role=\"status\">Counter 1 count: </div>");
#nullable restore
#line 9 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "role", "status");
            __builder.AddContent(6, "CounterState.Guid: ");
#nullable restore
#line (12,42)-(12,58) 24 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
__builder.AddContent(7, PurpleState.Guid);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n  ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "role", "status");
            __builder.AddContent(11, "Counter 1 count: ");
#nullable restore
#line (13,40)-(13,57) 25 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
__builder.AddContent(12, PurpleState.Count);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n  ");
            __builder.OpenElement(14, "button");
            __builder.AddAttribute(15, "onclick", global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
                    IncrementCount

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(16, "Click me");
            __builder.CloseElement();
#nullable restore
#line 15 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\Users\Admin\source\repos\blazor-state\Tests\Test.App\Test.App.Client\Features\Purple\Components\PurpleCounter.razor"
 
  private async Task IncrementCount() => await Mediator.Send(new PurpleState.IncrementCount.Action { Amount = 5 });

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
