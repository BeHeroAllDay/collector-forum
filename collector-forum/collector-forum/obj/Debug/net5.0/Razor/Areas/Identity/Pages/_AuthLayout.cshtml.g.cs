#pragma checksum "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_AuthLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8828ed2ab1007924c927ed3e37b62efaed46178a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages__AuthLayout), @"mvc.1.0.view", @"/Areas/Identity/Pages/_AuthLayout.cshtml")]
namespace AspNetCore
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
#line 1 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_ViewImports.cshtml"
using collector_forum.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_ViewImports.cshtml"
using collector_forum.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_ViewImports.cshtml"
using collector_forum.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8828ed2ab1007924c927ed3e37b62efaed46178a", @"/Areas/Identity/Pages/_AuthLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b4c7aa36a96b25f320be0bdbec0b8365b95754c", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    public class Areas_Identity_Pages__AuthLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_AuthLayout.cshtml"
   
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-5 offset-md-3\">\r\n        <div class=\"card\">\r\n            <div class=\"card-content\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-12\">\r\n                        ");
#nullable restore
#line 11 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_AuthLayout.cshtml"
                   Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 20 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Areas\Identity\Pages\_AuthLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
