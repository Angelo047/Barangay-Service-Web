#pragma checksum "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2914c530292b110a82f5f200e7b71dac6af7fbb5dab0b1ffff60b0da9f874827"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_clearanceClaimed), @"mvc.1.0.view", @"/Views/Admin/clearanceClaimed.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"2914c530292b110a82f5f200e7b71dac6af7fbb5dab0b1ffff60b0da9f874827", @"/Views/Admin/clearanceClaimed.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ed37e299d407f1ea2b4c12a2c0e33865bf75071abb03229994ece496696d6c29", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_clearanceClaimed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OSSP.Models.users>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
  
    Layout = "_Header";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">

    <!-- Page Heading -->
    <h1 class=""h3 mb-2 text-gray-800"">Barangay Clearance(Claimed)</h1>

    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">

        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">

                    <thead>
                        <tr>
                            <th>Details</th>
                            <th>Request No. </th>
                            <th>Resident No.</th>
                            <th>Last Name</th>
                            <th>First Name</th>
                            <th>Purpose</th>
                            <th>Date Applied</th>
                            <th>Date Claimed</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 31 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 1204, "\"", 1247, 2);
            WriteAttributeValue("", 1211, "clearanceView?reqNo=", 1211, 20, true);
#nullable restore
#line 35 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
WriteAttributeValue("", 1231, item.request_no, 1231, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-eye\"></i> View</a>\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.request_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.resident_accountBD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.last_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.first_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.purpose);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.dateString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 43 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                               Write(item.dateClaimedString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\clearanceClaimed.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n<script>\r\n\r\n    $(document).ready(function () {\r\n        $(\"#dataTable\").DataTable();\r\n    });\r\n</script>");
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