#pragma checksum "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d1307999e2302d3d8e8b420b827fad0c3baf2ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.view", @"/Views/Search/Index.cshtml")]
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
#line 1 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\_ViewImports.cshtml"
using UNIKProjekt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\_ViewImports.cshtml"
using UNIKProjekt.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
using Infrastructure.Interface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
using Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
using Domain.Models.ApartmentSearch;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d1307999e2302d3d8e8b420b827fad0c3baf2ed", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"568442933e85435526d936f914d6da00b638c84e", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Apartment>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("type"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("collapse on"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("area"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("others"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("beautify"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cl"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btnPrimary btnSmall full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToWishlist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btnDefault btnSmall full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<h1>Søg bolig</h1>

<div class=""col full cl leaseContainer"">
    <!-- Sidebar -->
    <div class=""col col-3 col-t-4 mcol-12 leaseSidebar"">
        <h2 onclick=""ToggleSlide(event, 'type')"">Boligtype <span class=""arrow Open"" id=""type-arrow""></span></h2>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed9304", async() => {
                WriteLiteral("\r\n            <ul>\r\n");
#nullable restore
#line 15 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                  
                    for (int i = 0; i < ApartmentSearchCriteriaData.Type.Count; i++)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>\r\n                            <label class=\"checkboxContainer\">\r\n                                ");
#nullable restore
#line 20 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                           Write(ApartmentSearchCriteriaData.Type[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <input type=\"checkbox\"");
                BeginWriteAttribute("id", " id=\"", 819, "\"", 831, 2);
                WriteAttributeValue("", 824, "apar-", 824, 5, true);
#nullable restore
#line 21 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
WriteAttributeValue("", 829, i, 829, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 832, "\"", 846, 2);
                WriteAttributeValue("", 839, "apar-", 839, 5, true);
#nullable restore
#line 21 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
WriteAttributeValue("", 844, i, 844, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <span class=\"checkboxItem\"></span>\r\n                            </label>\r\n                        </li>\r\n");
#nullable restore
#line 25 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
            WriteLiteral("\r\n\r\n\r\n\r\n        <h2 onclick=\"ToggleSlide(event, \'area\')\">Områder <span class=\"arrow Open\" id=\"area-arrow\"></span></h2>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed13087", async() => {
                WriteLiteral("\r\n            <ul>\r\n");
#nullable restore
#line 35 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                  
                    foreach(var key in ApartmentSearchCriteriaData.Area.Keys) {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>\r\n                            <label class=\"checkboxContainer\">\r\n                                ");
#nullable restore
#line 39 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                           Write(key);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 39 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                                Write(ApartmentSearchCriteriaData.Area[key]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <input type=\"checkbox\"");
                BeginWriteAttribute("id", " id=\"", 1582, "\"", 1596, 2);
                WriteAttributeValue("", 1587, "area-", 1587, 5, true);
#nullable restore
#line 40 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
WriteAttributeValue("", 1592, key, 1592, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 1597, "\"", 1613, 2);
                WriteAttributeValue("", 1604, "area-", 1604, 5, true);
#nullable restore
#line 40 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
WriteAttributeValue("", 1609, key, 1609, 4, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <span class=\"checkboxItem\"></span>\r\n                            </label>\r\n                        </li>\r\n");
#nullable restore
#line 44 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n        <h2 onclick=\"ToggleSlide(event, \'others\')\">Andre <span class=\"arrow Open\" id=\"others-arrow\"></span></h2>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed17125", async() => {
                WriteLiteral("\r\n            <ul>\r\n");
#nullable restore
#line 53 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                  
                    for (int i = 0; i < ApartmentSearchCriteriaData.Other.Count; i++)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>\r\n                            <label class=\"checkboxContainer\">\r\n                                ");
#nullable restore
#line 58 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                           Write(ApartmentSearchCriteriaData.Other[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <input type=\"checkbox\"");
                BeginWriteAttribute("id", " id=\"", 2374, "\"", 2387, 2);
                WriteAttributeValue("", 2379, "other-", 2379, 6, true);
#nullable restore
#line 59 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
WriteAttributeValue("", 2385, i, 2385, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 2388, "\"", 2403, 2);
                WriteAttributeValue("", 2395, "other-", 2395, 6, true);
#nullable restore
#line 59 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
WriteAttributeValue("", 2401, i, 2401, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <span class=\"checkboxItem\"></span>\r\n                            </label>\r\n                        </li>\r\n");
#nullable restore
#line 63 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>

    <!-- Content -->
    <div class=""col col-9 col-t-8 mcol-12 leaseContent"">
        <div class=""leaseContentInner cl"">
            <div class=""col col-6 col-t-6 mcol-12 no-margin"">
                <h2>Boligkriterier</h2>
            </div>

            <div class=""col col-6 col-t-6 mcol-12 no-margin"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed21133", async() => {
                WriteLiteral(@"
                    <ul class=""noMargin"">
                        <li class=""full"">
                            <input type=""search"" name=""s"" id=""s"" placeholder=""Søg efter adresse ..."">
                        </li>
                    </ul>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col full\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed23408", async() => {
                WriteLiteral(@"
                    <ul class=""cl"" style=""margin:0; padding: 0;"">
                        <li class=""col col-6 col-t-6 mcol-6"">
                            <label for=""minRent"">Min. Husleje</label>
                            <input type=""number"" name=""minRent"" id=""minRent"" minlength=""1"" value=""1000"" class=""full"">
                        </li>

                        <li class=""col col-6 col-t-6 mcol-6"">
                            <label for=""maxRent"">Max. Husleje</label>
                            <input type=""number"" name=""maxRent"" id=""maxRent"" minlength=""1"" value=""50000"" class=""full"">
                        </li>

                        <div class=""col full no-margin"">
                            <li class=""col col-3 col-t-3 mcol-6"">
                                <label for=""minRooms"">Min. Værelser</label>
                                <input type=""number"" name=""minRooms"" id=""minRooms"" minlength=""1"" value=""1"" class=""full"">
                            </li>

                     ");
                WriteLiteral(@"       <li class=""col col-3 col-t-3 mcol-6"">
                                <label for=""maxRooms"">Max. Værelser</label>
                                <input type=""number"" name=""maxRooms"" id=""maxRooms"" minlength=""1"" value=""5"" class=""full"">
                            </li>

                            <li class=""col col-3 col-t-3 mcol-6"">
                                <label for=""minSize"">Min. m<sup>2</sup></label>
                                <input type=""number"" name=""minSize"" id=""minSize"" minlength=""0"" value=""0"" class=""full"">
                            </li>

                            <li class=""col col-3 col-t-3 mcol-6"">
                                <label for=""maxSize"">Max. m<sup>2</sup></label>
                                <input type=""number"" name=""maxSize"" id=""maxSize"" minlength=""1"" value=""200"" class=""full"">
                            </li>
                        </div>

                        <div class=""col full no-margin"">
                            <li class=""f");
                WriteLiteral("ull\">\r\n                                <input type=\"submit\" class=\"btn btnPrimary\" style=\"margin: 0\" value=\"Opdater filtre\">\r\n                            </li>\r\n                        </div>\r\n                    </ul>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col full leaseItemContainer\">\r\n");
#nullable restore
#line 132 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
              
                if(Model.Count == 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h1 class=\"txt center\">Ingen lejemål tilgængelig</h1>\r\n                    <p class=\"txt center\">Kom tilbage igen senere, så er der måske et ledigt lejemål til dig.</p>\r\n");
#nullable restore
#line 136 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                }
                foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col col-4 col-t-4 mcol-6 leaseItem"" title=""Lorem ipsum dolor sit amet consectetur adipisicing elit. Sapiente quam fuga architecto repudiandae sunt tenetur enim atque consequatur accusamus doloribus, iste, id nostrum fugiat? Architecto consequuntur maiores quia non cumque!"">
                        <div class=""image"" style=""background-image:url(https://via.placeholder.com/250x200);""></div>
                        <div class=""content"">
                            <h3>");
#nullable restore
#line 142 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                           Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <small>");
#nullable restore
#line 143 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                              Write(item.Zip);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 143 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                                        Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            <div class=\"desc\">\r\n                                ");
#nullable restore
#line 145 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                           Write(item.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <h4>");
#nullable restore
#line 147 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                           Write(item.Rent);

#line default
#line hidden
#nullable disable
            WriteLiteral(",-/md</h4>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed30261", async() => {
                WriteLiteral("Se mere");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 148 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                                                                           WriteLiteral(item.ApartmentID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 149 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                             if (ua.isLoggedIn())
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d1307999e2302d3d8e8b420b827fad0c3baf2ed33107", async() => {
                WriteLiteral("Skriv mig op");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 151 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                                                                                        WriteLiteral(item.ApartmentID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 152 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 155 "C:\Users\shant\OneDrive\Dokumenter\GitHub\UnikProjekt\UNIKProjekt\UNIKProjekt\Views\Search\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserAuth ua { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Apartment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
