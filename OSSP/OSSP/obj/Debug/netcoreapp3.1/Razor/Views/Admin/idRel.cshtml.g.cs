#pragma checksum "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0d14d08b3f89d14801e007c12b04594764e45ee6995ffbe3932b2adfcffd3fa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_idRel), @"mvc.1.0.view", @"/Views/Admin/idRel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0d14d08b3f89d14801e007c12b04594764e45ee6995ffbe3932b2adfcffd3fa2", @"/Views/Admin/idRel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"ed37e299d407f1ea2b4c12a2c0e33865bf75071abb03229994ece496696d6c29", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_idRel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OSSP.Models.users>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
  
    Layout = "_Header";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<script src=""https://cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<div class=""container-fluid"">

    <!-- Page Heading -->
    <h1 class=""h3 mb-2 text-gray-800"">Barangay ID(Released)</h1>

    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">

        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                    <thead>
                        <tr>
                            <th>Details</th>
                            <th>ID No.</th>
                            <th>Resident No.</th>
                            <th>Last Name</th>
                            <th>First Name</th>
                            <th>Process</th>
               ");
            WriteLiteral("             <th>Date Applied</th>\r\n                            <th>Claim</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 32 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <a class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 1473, "\"", 1509, 2);
            WriteAttributeValue("", 1480, "idView?reqNo=", 1480, 13, true);
#nullable restore
#line 36 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
WriteAttributeValue("", 1493, item.request_no, 1493, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-eye\"></i> View</a>\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                               Write(item.request_no);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 39 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                               Write(item.resident_accountBD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 40 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                               Write(item.last_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 41 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                               Write(item.first_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 42 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                               Write(item.print_status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 43 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                               Write(item.dateString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <button type=\"button\" class=\"verifyBtn btn btn-success bg-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2095, "\"", 2130, 3);
            WriteAttributeValue("", 2105, "Claim(\'", 2105, 7, true);
#nullable restore
#line 45 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
WriteAttributeValue("", 2112, item.request_no, 2112, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2128, "\')", 2128, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-check-circle\"></i> Claim</button>\r\n                                </td>\r\n                                \r\n                            </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Alysa\source\repos\SYS\OSSP\OSSP\OSSP\Views\Admin\idRel.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>

</div>

<script>

    function Claim(reqNo) {
        var req = reqNo;
        Swal.fire({
            title: 'Do you want to Mark this as claimed?',
            showDenyButton: true,
            showCancelButton: false,
            confirmButtonText: 'Claim',
            confirmButtonColor: '#22bb33',
            denyButtonText: `Cancel`,
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Admin/UpdateIDC',
                    method: 'post',
                    data: { id: req },
                    dataType: 'json',
                    success: function (data) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Mark as claimed',
                            showCloseButton: true,
                        }).then((result) => {
                    ");
            WriteLiteral(@"        if (result) {
                                window.location.reload();
                            }
                        });
                    }
                });
            } else if (result.isDenied) {
                Swal.fire('Changes are not saved', '', 'info')
            }
        })
    }


    $(document).ready(function () {
        $(""#dataTable"").DataTable();
    });
</script>");
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
