#pragma checksum "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daa229b0388432c60a03147b3d1e0290e53f012f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Teacher_Detail), @"mvc.1.0.view", @"/Areas/Manage/Views/Teacher/Detail.cshtml")]
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
#line 1 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\_ViewImports.cshtml"
using eduhome.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\_ViewImports.cshtml"
using eduhome.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\_ViewImports.cshtml"
using eduhome.Data.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daa229b0388432c60a03147b3d1e0290e53f012f", @"/Areas/Manage/Views/Teacher/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b76f58859e5e02eb5f929dc4b14ef4ac4fd3c7ec", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Teacher_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:250px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("course image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
   ViewData["Title"] = "Delete";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";
     

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container-fluid\">\n    <h2>Detail</h2>\n    <div class=\"card-group\">\n        <div class=\"card\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "daa229b0388432c60a03147b3d1e0290e53f012f4990", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 243, "~/uploads/teachers/", 243, 19, true);
#nullable restore
#line 10 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
AddHtmlAttributeValue("", 262, Model.Photo, 262, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
            WriteLiteral("\n            <div class=\"card-body\">\n                <h5 class=\"card-title\">FullName: ");
#nullable restore
#line 12 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                            Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                <p class=\"card-text\">Teaching Status: ");
#nullable restore
#line 13 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                 Write(Model.TeachingStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Desc: ");
#nullable restore
#line 14 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                      Write(Html.Raw(Model.Desc));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">About Desc: ");
#nullable restore
#line 15 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                            Write(Model.Degree);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Apply Desc: ");
#nullable restore
#line 16 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                            Write(Model.Experience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Certification Desc: ");
#nullable restore
#line 17 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                    Write(Model.Hobby);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">About Desc: ");
#nullable restore
#line 18 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                            Write(Model.Faculty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Start: ");
#nullable restore
#line 19 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Duration: ");
#nullable restore
#line 20 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                          Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Hours: ");
#nullable restore
#line 21 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Skill Level: ");
#nullable restore
#line 22 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                             Write(Model.Skype);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Language Percentage: ");
#nullable restore
#line 23 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                     Write(Model.LanguagePercentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Design Percentage: ");
#nullable restore
#line 24 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                   Write(Model.DesignPercentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">TeamLeader Percentage: ");
#nullable restore
#line 25 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                       Write(Model.TeamLeaderPercentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">TeamLeader Percentage: ");
#nullable restore
#line 26 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                       Write(Model.CommunicationPercentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Innovation Percentage: ");
#nullable restore
#line 27 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                       Write(Model.InnovationPercentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                <p class=\"card-text\">Development Percentage: ");
#nullable restore
#line 28 "C:\Users\Elvin\Desktop\p120_backend_project-Elvin-Osmanov\eduhome\eduhome\Areas\Manage\Views\Teacher\Detail.cshtml"
                                                        Write(Model.DevelopmentPercentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            </div>\n        </div>\n    </div>\n\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; }
    }
}
#pragma warning restore 1591
