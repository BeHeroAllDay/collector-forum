#pragma checksum "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d17ade5de4c74864dff23e34c12cfa03c871ba65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ListUsers), @"mvc.1.0.view", @"/Views/Admin/ListUsers.cshtml")]
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
#line 1 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
using collector_forum.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d17ade5de4c74864dff23e34c12cfa03c871ba65", @"/Views/Admin/ListUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9cc01a66ae92d76c8dfd260974854d0132bf5df", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ListUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
  
    ViewBag.Title = "Users list";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"Lists\">\r\n\r\n    <h1 class=\"headersTable\">List of all users</h1>\r\n\r\n");
#nullable restore
#line 16 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
     if (Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""table-responsive-xl"">
            <table class=""table table-hover usersList"">
                <tr style=""font-size: 20px; marker:none;"">
                    <th scope=""col"">ID</th>
                    <th scope=""col"">User Name</th>
                    <th scope=""col"">Email</th>
                    <th scope=""col"">Rating</th>
                    <th scope=""col"" class=""align-middle"">Joined</th>
                    <th scope=""col"" class=""text-center align-middle"">Action</th>
                </tr>
");
#nullable restore
#line 27 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                 foreach (var user in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr style=\"font-size: 16px;\">\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 30 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                            Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 31 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                            Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 32 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                            Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle text-center\">");
#nullable restore
#line 33 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                                        Write(user.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"align-middle\">");
#nullable restore
#line 34 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                            Write(user.RegistrationDate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center align-middle\">\r\n                            <div btn-group align-middle>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d17ade5de4c74864dff23e34c12cfa03c871ba659729", async() => {
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d17ade5de4c74864dff23e34c12cfa03c871ba6510023", async() => {
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
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                                                                                              WriteLiteral(user.Id);

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
                WriteLiteral("\r\n                                    <button type=\"submit\" class=\"btn btn-danger\"");
                BeginWriteAttribute("onclick", "\r\n                                            onclick=\"", 1778, "\"", 1904, 12);
                WriteAttributeValue("", 1833, "return", 1833, 6, true);
                WriteAttributeValue(" ", 1839, "confirm(\'Are", 1840, 13, true);
                WriteAttributeValue(" ", 1852, "you", 1853, 4, true);
                WriteAttributeValue(" ", 1856, "sure", 1857, 5, true);
                WriteAttributeValue(" ", 1861, "you", 1862, 4, true);
                WriteAttributeValue(" ", 1865, "want", 1866, 5, true);
                WriteAttributeValue(" ", 1870, "to", 1871, 3, true);
                WriteAttributeValue(" ", 1873, "delete", 1874, 7, true);
                WriteAttributeValue(" ", 1880, "user", 1881, 5, true);
                WriteAttributeValue(" ", 1885, ":", 1886, 2, true);
#nullable restore
#line 40 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
WriteAttributeValue(" ", 1887, user.UserName, 1888, 14, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1902, "\')", 1902, 2, true);
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
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                                                                WriteLiteral(user.Id);

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
            WriteLiteral("\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 47 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n");
#nullable restore
#line 50 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <hr />
        <div class=""row"">
            <div class=""col-md-6 offset-md-3"">
                <h5 style=""padding: 40px 0px 0px 0px; text-align: center;"">There is no accounts created yet</h5>
                <div class=""col text-center"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d17ade5de4c74864dff23e34c12cfa03c871ba6517511", async() => {
                WriteLiteral("\r\n                        Return to main page\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 64 "D:\Piotrek\Desktop\Praca inżynierska\App\collector-forum\collector-forum\collector-forum\Views\Admin\ListUsers.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
