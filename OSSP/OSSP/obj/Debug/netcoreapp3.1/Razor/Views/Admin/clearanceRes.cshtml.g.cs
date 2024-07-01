#pragma checksum "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "391a218e923de47ae5951aa42c9adce6e0af13f0ea4203377400bf73a01602df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_clearanceRes), @"mvc.1.0.view", @"/Views/Admin/clearanceRes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"391a218e923de47ae5951aa42c9adce6e0af13f0ea4203377400bf73a01602df", @"/Views/Admin/clearanceRes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ed37e299d407f1ea2b4c12a2c0e33865bf75071abb03229994ece496696d6c29", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_clearanceRes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OSSP.Models.users>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
  
    Layout = "_Header";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<script src=""https://cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<div class=""container-fluid"">

    <!-- Page Heading -->
    <h1 class=""h3 mb-2 text-gray-800"">Barangay Clearance(Resubmit)</h1>

    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">

        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">

                    <thead>
                        <tr>
                            <th>Details</th>
                            <th>Request No.</th>
                            <th>Resident No.</th>
                            <th>Last Name</th>
                            <th>First Name</th>
                            <th>Purpose</th>
 ");
            WriteLiteral("                           <th>Date Applied</th>\r\n\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 1445, "\"", 1488, 2);
            WriteAttributeValue("", 1452, "clearanceView?reqNo=", 1452, 20, true);
#nullable restore
#line 37 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
WriteAttributeValue("", 1472, item.request_no, 1472, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-eye\"></i> View</a>\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                               Write(item.request_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                               Write(item.resident_accountBD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                               Write(item.last_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                               Write(item.first_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 43 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                               Write(item.purpose);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 44 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                               Write(item.dateString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 47 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceRes.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n<script>\r\n\r\n    $(document).ready(function () {\r\n        $(\"#dataTable\").DataTable();\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OSSP.Models.users>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591