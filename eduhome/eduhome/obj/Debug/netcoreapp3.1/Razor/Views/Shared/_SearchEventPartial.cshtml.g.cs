#pragma checksum "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\Shared\_SearchEventPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73f0027ec040e37192daea48a3cd86797f738ae8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchEventPartial), @"mvc.1.0.view", @"/Views/Shared/_SearchEventPartial.cshtml")]
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
#line 1 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\_ViewImports.cshtml"
using eduhome.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\_ViewImports.cshtml"
using eduhome.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\_ViewImports.cshtml"
using eduhome.Data.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73f0027ec040e37192daea48a3cd86797f738ae8", @"/Views/Shared/_SearchEventPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58567e2e57c1602b9d556e692668eb640b8d6027", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchEventPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Event>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\Shared\_SearchEventPartial.cshtml"
 foreach (Event eventmodel in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li style=\"display:flex\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 104, "\"", 139, 2);
            WriteAttributeValue("", 111, "/Event/Detail/", 111, 14, true);
#nullable restore
#line 6 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\Shared\_SearchEventPartial.cshtml"
WriteAttributeValue("", 125, eventmodel.Id, 125, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 6 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\Shared\_SearchEventPartial.cshtml"
                                          Write(eventmodel.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </li>\r\n");
#nullable restore
#line 8 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Views\Shared\_SearchEventPartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
