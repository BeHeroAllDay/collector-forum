#pragma checksum "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ae7cc149b56fdd7201a93b9e2c6d4a02e567fc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
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
#line 1 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\_ViewImports.cshtml"
using collector_forum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\_ViewImports.cshtml"
using collector_forum.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
using collector_forum.Models.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
using collector_forum.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ae7cc149b56fdd7201a93b9e2c6d4a02e567fc1", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9cc01a66ae92d76c8dfd260974854d0132bf5df", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ItemListingModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
  
    ViewBag.Title = "Items list";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""Lists"">
    <div class=""headersTable"">
        <h1>List of items selected user</h1>
        <h3>To manage your items first add one!</h3>
    </div>
    <div class=""table-responsive-xl"">
        <input hidden />
        <table class=""table table-hover usersList"">
            <tr style=""font-size: 20px; marker:none;"">
                <th scope=""col"">Name</th>
                <th scope=""col"">Description</th>
                <th scope=""col"">Author</th>
                <th scope=""col"">Added</th>
                <th scope=""col"">Updated</th>
");
#nullable restore
#line 30 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                 if (Context.User.Identity.Name == Model.First().UserName || User.IsInRole("Admin") || User.IsInRole("Mod"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th scope=\"col\" class=\"text-center align-middle\">Action</th>\r\n");
#nullable restore
#line 33 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tr>\r\n");
#nullable restore
#line 36 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr style=\"font-size: 16px;\">\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 39 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 40 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                        Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 41 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                        Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 42 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                        Write(item.Added);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 43 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                        Write(item.Updated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 44 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                     if (item.UserId.Contains(userManager.GetUserId(User)) || User.IsInRole("Admin") || User.IsInRole("Mod"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td class=\"text-center align-middle\">\r\n                            <div btn-group align-middle>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ae7cc149b56fdd7201a93b9e2c6d4a02e567fc110064", async() => {
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ae7cc149b56fdd7201a93b9e2c6d4a02e567fc110359", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-itemId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["itemId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-itemId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["itemId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    <button type=\"submit\" class=\"btn btn-danger\"");
                BeginWriteAttribute("onclick", "\r\n                                            onclick=\"", 2233, "\"", 2354, 11);
                WriteAttributeValue("", 2288, "return", 2288, 6, true);
                WriteAttributeValue(" ", 2294, "confirm(\'Are", 2295, 13, true);
                WriteAttributeValue(" ", 2307, "you", 2308, 4, true);
                WriteAttributeValue(" ", 2311, "sure", 2312, 5, true);
                WriteAttributeValue(" ", 2316, "you", 2317, 4, true);
                WriteAttributeValue(" ", 2320, "want", 2321, 5, true);
                WriteAttributeValue(" ", 2325, "to", 2326, 3, true);
                WriteAttributeValue(" ", 2328, "delete", 2329, 7, true);
                WriteAttributeValue(" ", 2335, "post:", 2336, 6, true);
#nullable restore
#line 51 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
WriteAttributeValue(" ", 2341, item.Name, 2342, 10, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2352, "\')", 2352, 2, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        Delete\r\n                                    </button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </td>\r\n");
#nullable restore
#line 57 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 59 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Profile\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ItemListingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
