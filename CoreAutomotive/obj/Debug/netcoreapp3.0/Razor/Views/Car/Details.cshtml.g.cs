#pragma checksum "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e175ebef094b8f44f5c23dac740e25947ad5a520"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoreAutomotive.Views.Car.Views_Car_Details), @"mvc.1.0.view", @"/Views/Car/Details.cshtml")]
namespace CoreAutomotive.Views.Car
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/_ViewImports.cshtml"
using CoreAutomotive.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/_ViewImports.cshtml"
using CoreAutomotive.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e175ebef094b8f44f5c23dac740e25947ad5a520", @"/Views/Car/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d00897155be5e59d95459ec512596afd53677dde", @"/Views/_ViewImports.cshtml")]
    public class Views_Car_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Samochod>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div>\n    <div class=\"thumbnail\">\n        <div class=\"row\">\n            <div class=\"col-md-6\">\n                <img");
            BeginWriteAttribute("alt", " alt=\"", 132, "\"", 150, 1);
#nullable restore
#line 7 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
WriteAttributeValue("", 138, Model.Marka, 138, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 151, "\"", 174, 1);
#nullable restore
#line 7 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
WriteAttributeValue("", 157, Model.ZdjecieUrl, 157, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"500\" width=\"500\" />\n            </div>\n            <div class=\"col-md-3\">\n                <h3>");
#nullable restore
#line 10 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
               Write(Model.Marka);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 10 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
                              Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                <h4>");
#nullable restore
#line 11 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
               Write(Model.Cena);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                <h4>");
#nullable restore
#line 12 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
               Write(Model.RokProdukcji);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                <h4>");
#nullable restore
#line 13 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
               Write(Model.Przebieg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                <h4>");
#nullable restore
#line 14 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
               Write(Model.Pojemnosc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                <h4>");
#nullable restore
#line 15 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
               Write(Model.Moc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                <p>");
#nullable restore
#line 16 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
              Write(Model.Opis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            </div>\n            <div class=\"col-md-3\" style=\"padding-right:50px\">\n                <h3 class=\"pull-right\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e175ebef094b8f44f5c23dac740e25947ad5a5207293", async() => {
                WriteLiteral("Edycja");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Car/Details.cshtml"
                                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e175ebef094b8f44f5c23dac740e25947ad5a5209522", async() => {
                WriteLiteral("Powrót");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </h3>\n            </div>\n        </div>\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Samochod> Html { get; private set; }
    }
}
#pragma warning restore 1591
