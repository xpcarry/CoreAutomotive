#pragma checksum "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4aa96037a4b0a2ca365e2e412bbb64588867b976"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoreAutomotive.Views.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace CoreAutomotive.Views.Home
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aa96037a4b0a2ca365e2e412bbb64588867b976", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2fdbebfd41b4e3f0f8bc84632556fe627103ba6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreAutomotive.ViewModels.HomeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Szczegoly", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n\n<div class=\"row\"><h1>");
#nullable restore
#line 4 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                Write(Model.Tytul);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1></div>\n<div class=\"row\">\n");
#nullable restore
#line 6 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
     foreach (var samochod in Model.Samochody)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-sm-4 col-lg-4 col-md-4\">\n            <div class=\"img-thumbnail\">\n                <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 285, "\"", 314, 1);
#nullable restore
#line 10 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
WriteAttributeValue("", 291, samochod.MiniaturkaUrl, 291, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 315, "\"", 321, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                <div class=\"caption\">\n                    <h4 class=\"pull-right\">");
#nullable restore
#line 12 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                                      Write(samochod.Cena.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                    <h4>\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4aa96037a4b0a2ca365e2e412bbb64588867b9765239", async() => {
#nullable restore
#line 14 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                                                                                               Write(samochod.Marka);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                                                                          WriteLiteral(samochod.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("- ");
#nullable restore
#line 14 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                                                                                                                    Write(samochod.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 14 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                                                                                                                                      Write(samochod.RokProdukcji);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </h4>\n                    <h5>\n                        Przebieg : ");
#nullable restore
#line 17 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                              Write(samochod.Przebieg);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </h5>\n                    <h5>\n                        Pojemność : ");
#nullable restore
#line 20 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                               Write(samochod.Pojemnosc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </h5>\n                    <h5>\n                        Moc : ");
#nullable restore
#line 23 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                         Write(samochod.Moc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </h5>\n                    <p>");
#nullable restore
#line 25 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
                  Write(samochod.Opis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                </div>\n            </div>\n        </div>\n");
#nullable restore
#line 29 "/Users/albertbedynski/Projects/CoreAutomotive/CoreAutomotive/Views/Home/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreAutomotive.ViewModels.HomeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591