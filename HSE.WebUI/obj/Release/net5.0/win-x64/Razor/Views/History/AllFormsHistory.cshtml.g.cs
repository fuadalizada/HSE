#pragma checksum "D:\VisualStudio2019\HSE\HSE.WebUI\Views\History\AllFormsHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49d47887bcdd7b7b62507d86031a73eb3f20ed65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_History_AllFormsHistory), @"mvc.1.0.view", @"/Views/History/AllFormsHistory.cshtml")]
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
#line 1 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\_ViewImports.cshtml"
using HSE.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\_ViewImports.cshtml"
using HSE.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49d47887bcdd7b7b62507d86031a73eb3f20ed65", @"/Views/History/AllFormsHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a08528a351f7b3decbca5ab8c42032570770cc", @"/Views/_ViewImports.cshtml")]
    public class Views_History_AllFormsHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/customScripts/history/historyAllForms.js?v=66"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\History\AllFormsHistory.cshtml"
  
    ViewData["Title"] = "AllFormsHistory";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49d47887bcdd7b7b62507d86031a73eb3f20ed653966", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"
<div class=""row mt-2"">
    <div class=""table-responsive"">
        <table id=""historyForms"" class=""table table-hover table-bordered"" style=""width: 100%;"">
            <thead>
                <tr>
                    <th class=""thFormId"" style=""width: 75px !important;"">Form №<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                    <th class=""thFormCreateDate"">Hazırlanma tarixi<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                    <th class=""thInstructorFullName"">Təlimatçının adı,soyadı<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                    <th class=""thInstructorOrganizationFullName"">Təlimatçının strukturu<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                    <th class=""thInstructorjobName"">Təlimatçının vəzifəsi<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                    <th class=""thInstructionType"" s");
            WriteLiteral(@"tyle=""width: 100px !important;"">Təlimatın növü<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                    <th class=""thInstructionStatus"" style=""width: 100px !important;"">Status<br /><input type=""text"" placeholder=""&#xF002;"" class=""form-control"" /></th>
                </tr>
            </thead>
        </table>
    </div>
</div>

");
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
