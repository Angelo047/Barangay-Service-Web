#pragma checksum "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Home\Verification.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4e92203715246f5db734d58ec0173a8ed5cba3ba493bc4ec3abffd36f6e86484"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Verification), @"mvc.1.0.view", @"/Views/Home/Verification.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4e92203715246f5db734d58ec0173a8ed5cba3ba493bc4ec3abffd36f6e86484", @"/Views/Home/Verification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ed37e299d407f1ea2b4c12a2c0e33865bf75071abb03229994ece496696d6c29", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Verification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/sb-logos.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:70px; height:70px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ForgotPassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">

<title>Verification</title>
<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
<script src=""https://cdn.jsdelivr.net/npm/sweetalert2@11""></script>

<link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"" crossorigin=""anonymous"">
<link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css"">
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<title>Verify Account</title>
<script src=""https://cdn.jsdelivr.net/npm/sweetalert2@11""></script>

<style>
    .containers {
        height: 59vh;
  ");
            WriteLiteral(@"      width: 100%;
    }

        .containers .row {
            margin-top: 20px;
        }

            .containers .row .card {
                width: 500px;
                height: 500px;
            }

            .containers .row .input-group {
                width: 450px;
            }
</style>
<nav class=""navbar sticky-top navbar-expand-lg navbar-dark"" style=""background-color: #208454 "">
    <div class=""container-fluid"">
        <a class=""navbar-brand"" href=""#"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4e92203715246f5db734d58ec0173a8ed5cba3ba493bc4ec3abffd36f6e864847190", async() => {
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
            WriteLiteral(@" BRGY PORTAL</a>
    </div>
</nav>


<div class=""containers d-flex justify-content-center mt-5 mb-5"">
    <div class=""row"">
        <div class=""row"">
            <div class=""col-md-12 col-md-offset-12 card shadow-lg"">
                <div class=""panel panel-default border-top border-3 border-primary"">
                    <div class=""panel-body"">
                        <br />
                        <a onclick=""window.history.back()"" class=""fa fa-arrow-left"" style=""font-size:16px; text-decoration:none; color:black;""> Back</a>

                        <div class=""text-center"">
                            <h3><i class=""fa fa-lock fa-4x mt-5""></i></h3>
                            <h2 class=""text-center"">Code Verification</h2>
                            <p>Did not receive code yet?<a id=""resend"" style=""text-decoration:underline; color:blue""> Resend<a /></p>
                            <div class=""panel-body"">

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e92203715246f5db734d58ec0173a8ed5cba3ba493bc4ec3abffd36f6e864849411", async() => {
                WriteLiteral(@"
                                    <fieldset>
                                        <div class=""form-group"">
                                            <div class=""input-group"">
                                                <span class=""input-group-text"" id=""basic-addon1""><i class=""bi bi-code""></i></span>

                                                <input type=""text"" name=""code"" id=""code"" placeholder=""Code"" class=""form-control"" required>
                                            </div>
                                        </div>
                                        <div class=""form-group"">
                                            <input type=""button"" value=""Submit"" id=""submitButton"" class=""btn btn-lg btn-primary btn-block"">
                                        </div>
                                    </fieldset>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                    <br /><br /><br /><br />
                </div>
            </div>
        </div>
    </div>
</div>


<script>
    $(""#submitButton"").click(function () {
        $.ajax({
            url: '/Home/Verify',
            method: 'post',
            data: { id: $(""#code"").val() },
            dataType: 'json',
            success: function (data) {
                if (data.data == ""success"") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Done',
                        text: 'We will notify you once your account is verified.',
                        showCloseButton: true,
                    }).then((result) => {
                        if (result) {
                            window.location.href = '/Home/UpdateUnvAcc';
                        }
                    });
                }
                else {
");
            WriteLiteral(@"                    Swal.fire({
                        icon: 'error',
                        text: 'Code did not match!',
                        showCloseButton: true,
                    });
                }

            }
        });
    });

    $(""#resend"").click(function () {

        $.ajax({
            url: '/Home/GetCode2',
            method: 'post',
            dataType: 'json',
            beforeSend: function (data) {
                Swal.fire({
                    title: 'Please Wait...',
                    didOpen: () => {
                        Swal.showLoading()
                    },
                    allowOutsideClick: false,
                    showCancelButton: false,
                    showConfirmButton: false,
                })
            },
            success: function (data) {
                if (data.msg == ""error"") {
                    Swal.fire({
                        icon: 'error',
                        title: 'The code you have ent");
            WriteLiteral(@"ered did not match!',
                        showCloseButton: true,
                    })
                } else if (data.msg == ""success"") {
                    Swal.fire({
                        icon: 'success',
                        title: 'Code Resent',
                        showCloseButton: true,
                    })
                }


            }
        });
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591