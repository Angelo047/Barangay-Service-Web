#pragma checksum "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Profile), @"mvc.1.0.view", @"/Views/Admin/Profile.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\_ViewImports.cshtml"
using OSSP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\_ViewImports.cshtml"
using OSSP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd5", @"/Views/Admin/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ed37e299d407f1ea2b4c12a2c0e33865bf75071abb03229994ece496696d6c29", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OSSP.Models.users>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fa fa-arrow-left"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:24px; margin-top:24px; text-decoration:none; color:black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/sb-logos.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("250px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("180px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ChangeEmail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control form-control-sm bg-success text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Changepass"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<title>Profile</title>
<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
<script src=""https://cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<div class=""container"" style=""background-color: #f7efe2; margin-top:8px;"">
    <div>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd58582", async() => {
                WriteLiteral("  Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n    <center>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd59889", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <h4 style=\"padding-bottom:12px;\">Profile</h4>\r\n    </center>\r\n</div>\r\n\r\n\r\n\r\n<div class=\"container\">\r\n    <h3>Personal Information</h3>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd511367", async() => {
                WriteLiteral("\r\n    <div class=\"border container\">\r\n\r\n\r\n        <div class=\"row\" style=\"margin-top:6px;\">\r\n\r\n            <div class=\"col-md-3 \">\r\n                First Name:\r\n                <input type=\"text\" name=\"name\" class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 1338, "\"", 1363, 1);
#nullable restore
#line 33 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 1346, Model.first_name, 1346, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n            </div>\r\n\r\n            <div class=\"col-md-3\">\r\n                Last Name:\r\n                <input type=\"text\" name=\"name\" class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 1545, "\"", 1569, 1);
#nullable restore
#line 38 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 1553, Model.last_name, 1553, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n            </div>\r\n\r\n            <div class=\"col-md-3\">\r\n                Middle Name:\r\n                <input type=\"text\" name=\"name\" class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 1753, "\"", 1779, 1);
#nullable restore
#line 43 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 1761, Model.middle_name, 1761, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n            </div>\r\n\r\n            <div class=\"col-md-3\">\r\n                Suffix:\r\n                <input type=\"text\" name=\"name\" class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 1958, "\"", 1979, 1);
#nullable restore
#line 48 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 1966, Model.suffix, 1966, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" disabled>
            </div>

        </div>
        <br />
    </div>

    <div class=""border container"">
        <div class=""row"" style=""margin-top:6px; margin-bottom:6px;"">
            <div class=""col-md-3"">
                Birthdate:
                <input type=""text"" name=""name"" class=""form-control form-control-sm""");
                BeginWriteAttribute("value", " value=\"", 2313, "\"", 2340, 1);
#nullable restore
#line 59 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 2321, Model.birthdayDesc, 2321, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n            </div>\r\n\r\n            <div class=\"col-md-3\"");
                BeginWriteAttribute("style", " style=\"", 2408, "\"", 2416, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                Sex:\r\n                <input class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 2501, "\"", 2522, 1);
#nullable restore
#line 64 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 2509, Model.gender, 2509, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n\r\n            </div>\r\n            <div class=\"col-md-3\"");
                BeginWriteAttribute("style", " style=\"", 2590, "\"", 2598, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                Civil Status:\r\n                <input class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 2692, "\"", 2719, 1);
#nullable restore
#line 69 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 2700, Model.civil_status, 2700, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n            </div>\r\n            <div class=\"col-md-3\">\r\n                Nationality:\r\n                <input type=\"text\" name=\"name\" class=\"form-control form-control-sm\"");
                BeginWriteAttribute("value", " value=\"", 2901, "\"", 2927, 1);
#nullable restore
#line 73 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 2909, Model.nationality, 2909, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" disabled>
            </div>
        </div>
        <br />
    </div>

    <div class=""border container"">
        <div class=""row"" style=""margin-top:6px; margin-bottom:6px;"">

            <div class=""col-md-4"">
                Email Address:
                <input type=""email"" name=""name"" class=""form-control form-control-sm""");
                BeginWriteAttribute("value", " value=\"", 3266, "\"", 3294, 1);
#nullable restore
#line 84 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 3274, Model.email_address, 3274, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled>\r\n            </div>\r\n\r\n            <div class=\"col-md-4\"");
                BeginWriteAttribute("style", " style=\"", 3362, "\"", 3370, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                Phone Number:\r\n                <input type=\"text\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 3451, "\"", 3478, 1);
#nullable restore
#line 89 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 3459, Model.phone_number, 3459, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control form-control-sm\" disabled>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"row\" style=\"margin-top:6px; margin-bottom:6px;\">\r\n            <div class=\"col-md-2\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd518369", async() => {
                    WriteLiteral("<span class=\"fa fa-edit\"> </span> Change Email");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3697, "~/Admin/ChangeEmail/", 3697, 20, true);
#nullable restore
#line 95 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
AddHtmlAttributeValue("", 3717, Context.Session.GetString("admin"), 3717, 35, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>
            <br />
        </div>
    </div>
    <div class=""container"">
        <br />
        <h3>Present Address</h3>
    </div>
    <div class=""border container"">
        <div class=""row"" style=""margin-top:6px; margin-bottom:6px;"">
            <div class=""col-md-4"">
                House No.:
                <input type=""text"" name=""name""");
                BeginWriteAttribute("value", " value=\"", 4269, "\"", 4296, 1);
#nullable restore
#line 108 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 4277, Model.house_number, 4277, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control form-control-sm\" disabled>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                Street:\r\n                <input type=\"text\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 4473, "\"", 4494, 1);
#nullable restore
#line 112 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
WriteAttributeValue("", 4481, Model.street, 4481, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control form-control-sm"" disabled>
            </div>

        </div>
        <br />
    </div>
    <div class=""border container"">
        <div class=""row"" style=""margin-top:6px; margin-bottom:6px;"">
            <div class=""col-md-2"">
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5de9daa60743dc046515a58d45098b2e74a56cb20d9afe3d16cce7d66a388dd521936", async() => {
                    WriteLiteral("<span class=\"fa fa-edit\"> </span> Change Password");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4777, "~/Admin/ChangePassword/", 4777, 23, true);
#nullable restore
#line 121 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\Profile.cshtml"
AddHtmlAttributeValue("", 4800, Context.Session.GetString("admin"), 4800, 35, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n\r\n\r\n        </div>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\n\r\n\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OSSP.Models.users> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591