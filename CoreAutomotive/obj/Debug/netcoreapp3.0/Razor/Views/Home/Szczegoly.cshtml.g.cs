#pragma checksum "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0df0aaea26a33cd450f3ee0b12a1797545cc7727"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CoreAutomotive.Views.Home.Views_Home_Szczegoly), @"mvc.1.0.view", @"/Views/Home/Szczegoly.cshtml")]
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
#line 1 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\_ViewImports.cshtml"
using CoreAutomotive.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\_ViewImports.cshtml"
using CoreAutomotive.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0df0aaea26a33cd450f3ee0b12a1797545cc7727", @"/Views/Home/Szczegoly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8c40a9f754edd83a74450b445cc4b0cec27041e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Szczegoly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Samochod>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <h2> ");
#nullable restore
#line 5 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
    Write(Model.Marka);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 5 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
                 Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    <div class=\"thumbnail\">\r\n        <img");
            BeginWriteAttribute("alt", " alt=\"", 130, "\"", 148, 1);
#nullable restore
#line 8 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
WriteAttributeValue("", 136, Model.Marka, 136, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 149, "\"", 172, 1);
#nullable restore
#line 8 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
WriteAttributeValue("", 155, Model.ZdjecieUrl, 155, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <div class=\"caption-full\">\r\n            <h3 class=\"pull-right\">");
#nullable restore
#line 10 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
                              Write(Model.Cena);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <h4>");
#nullable restore
#line 11 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
           Write(Model.RokProdukcji);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h4>");
#nullable restore
#line 12 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
           Write(Model.Przebieg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h4>");
#nullable restore
#line 13 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
           Write(Model.RokProdukcji);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h4>");
#nullable restore
#line 14 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
           Write(Model.Pojemnosc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h4>");
#nullable restore
#line 15 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
           Write(Model.Moc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <p>");
#nullable restore
#line 16 "C:\Users\Albert\source\repos\CoreAutomotive\CoreAutomotive\Views\Home\Szczegoly.cshtml"
          Write(Model.Opis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n</div>");
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
