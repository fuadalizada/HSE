#pragma checksum "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Form_RetrieveFormResult), @"mvc.1.0.view", @"/Views/Form/RetrieveFormResult.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feb5e186dae7da4c1d93bd21bd8bfc95d134c64b", @"/Views/Form/RetrieveFormResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a08528a351f7b3decbca5ab8c42032570770cc", @"/Views/_ViewImports.cshtml")]
    public class Views_Form_RetrieveFormResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RetrieveFormResultViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/shared/bootstrap-daterangepicker/daterangepicker.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/customStyles/form/createForm.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/shared/bootstrap-daterangepicker/moment.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/customScripts/retrieveFormResult/retrieveFormResult.js?v=66"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/customScripts/webcam/webcam.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
  
    ViewData["Title"] = "RetrieveFormResult";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b6092", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b7270", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b8604", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b9765", async() => {
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-4 col-xl-1\">\r\n            <label class=\"title\">Form ???</label>\r\n            <input readonly");
                BeginWriteAttribute("value", " value=\"", 537, "\"", 573, 1);
#nullable restore
#line 22 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
WriteAttributeValue("", 545, Model.InstructionFormDto.Id, 545, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control instructionFormId\"/>\r\n        </div>\r\n\r\n        <div class=\"col-sm-4 col-xl-3 col-md-offset-4 col-md-2\">\r\n            <label class=\"title\">T??limat????n??n ad??,soyad??</label>\r\n            <input readonly");
                BeginWriteAttribute("value", " value=\"", 794, "\"", 846, 1);
#nullable restore
#line 27 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
WriteAttributeValue("", 802, Model.InstructionFormDto.InstructorFullName, 802, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control nameSurnameCopy""/>
        </div>
    </div>

    <div class=""row mt-1"">
        <div class=""col-sm-4 col-xl-2"">
            <label class=""title"">Haz??rlanma tarixi</label>
            <div class=""input-group"" id=""createDateCopy"">
                <input readonly type=""text"" class=""form-control"" name=""createDateCopy"" data-target=""#createDateCopy""");
                BeginWriteAttribute("value", " value=\"", 1222, "\"", 1294, 1);
#nullable restore
#line 35 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
WriteAttributeValue("", 1230, Model.InstructionFormDto.InstructionDate.ToString("dd/MM/yyyy"), 1230, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"/>
                <div class=""input-group-append"">
                    <div class=""input-group-text""><i class=""fa fa-calendar""></i></div>
                </div>
            </div>
        </div>

        <div class=""col-sm-4 col-xl-3 col-md-offset-3 col-md-2"">
            <label class=""title"">T??limat????n??n v??zif??si</label>
            <input readonly");
                BeginWriteAttribute("value", " value=\"", 1656, "\"", 1708, 1);
#nullable restore
#line 44 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
WriteAttributeValue("", 1664, Model.InstructionFormDto.InstructorPosition, 1664, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control instructorpositionCopy""/>
        </div>
    </div>

    <div class=""row mt-2"">
        <div class=""col-sm-4 col-xl-2"">
            <label class=""title"">T??limat??n n??v??</label>
            <select disabled id=""InstructionTypeCopy"" name=""InstructionType"" class=""select"">
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b13104", async() => {
#nullable restore
#line 52 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                                                                       Write(Model.InstructionFormDto.InstructionTypeName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                   WriteLiteral(Model.InstructionFormDto.InstructionTypeId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </select>
        </div>
    </div>

    <div class=""row mt-2"">
        <div class=""col-sm-4 col-xl-5"">
            <label class=""title"">T??limat??n q??sa m??zmunu</label>
            <textarea disabled id=""ShortContentRetrieveResult"" name=""ShortContentCopy"" class=""form-control"" style=""resize: none; overflow: hidden; min-height: 50px;"">");
#nullable restore
#line 60 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                                                                                                                                                                 Write(Model.InstructionFormDto.InstructionShortContent);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</textarea>
        </div>
    </div>

    <div class=""row mt-3"">
        <div class=""col-sm-4 col-xl-3"">
            <label class=""title"">T??limatland??r??lan ????xsl??rin m??lumatlar??</label>
        </div>
    </div>

    <div class=""row mt-1"">
        <div class=""table-responsive"">
            <table class=""table table-bordered table-hover instructor_Notes_Copy"" id=""InstructorNotesCopy"">
                <thead class=""table table-bordered"" style=""background-color: gainsboro"">
                <tr>
                    <th style=""font-size: 12px; text-align: left"">???</th>
                    <th style=""font-size: 12px; text-align: left"">T??limatland??r??lan ????xsin ad??, soyad??, ata at??</th>
                    <th style=""font-size: 12px; text-align: center"">V??zif??si</th>
                    <th style=""font-size: 12px; text-align: left"">T??limat????n??n r??yi</th>
                    <th style=""font-size: 12px; text-align: center; width: 100px;"">Statusu</th>
                </tr>
                </thead>
");
                WriteLiteral("                <tbody>\r\n\r\n");
#nullable restore
#line 84 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                  
                    var counter = 0;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                 foreach (var item in Model.EmployeeFormDtos)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 90 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                        Write(++counter);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 91 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                       Write(item.EmployeeFullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 92 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                       Write(item.EmployeePosition);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 93 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                       Write(item.InstructorComment);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 94 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                         if (item.IsActive == true)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td style=\"width: 100px; text-align: center\"><button data-employeeFullName=\"");
#nullable restore
#line 96 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                                                                                                   Write(item.EmployeeFullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" data-employeeUserId=\"");
#nullable restore
#line 96 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                                                                                                                                                Write(item.EmployeeUserId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" title=\"T??sdiq?? g??nd??r\" type=\"button\" class=\"btn openPopUp\" id=\"openPictureModal\"><i class=\"fas fa-arrow-right\" style=\"font-size: 20px; color: red\"></i></button></td>\r\n");
#nullable restore
#line 97 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td style=\"width: 100px; text-align: center;\"><button data-employeeFullName=\"");
#nullable restore
#line 100 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                                                                                                    Write(item.EmployeeFullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" data-employeeUserId=\"");
#nullable restore
#line 100 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                                                                                                                                                 Write(item.EmployeeUserId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" title=\"T??sdiql??nib\" type=\"button\" class=\"btn ShowPicturePopUp\" id=\"openPictureModal\"><i class=\"fas fa-eye\" style=\"font-size: 20px; color: green\" aria-hidden=\"true\"></i></button></td>\r\n");
#nullable restore
#line 101 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 103 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n            ");
#nullable restore
#line 106 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
       Write(await Html.PartialAsync("_takeApictureModal"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 107 "D:\VisualStudio2019\HSE\HSE.WebUI\Views\Form\RetrieveFormResult.cshtml"
       Write(await Html.PartialAsync("_showPhotoModal"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b23146", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "feb5e186dae7da4c1d93bd21bd8bfc95d134c64b24186", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RetrieveFormResultViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
