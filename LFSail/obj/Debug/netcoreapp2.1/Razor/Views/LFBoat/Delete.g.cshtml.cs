#pragma checksum "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f96c68b6e5ed99e5fe521febdc5b0710b83b04d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LFBoat_Delete), @"mvc.1.0.view", @"/Views/LFBoat/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/LFBoat/Delete.cshtml", typeof(AspNetCore.Views_LFBoat_Delete))]
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
#line 1 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\_ViewImports.cshtml"
using LFSail;

#line default
#line hidden
#line 2 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\_ViewImports.cshtml"
using LFSail.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f96c68b6e5ed99e5fe521febdc5b0710b83b04d", @"/Views/LFBoat/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"831f5529659afadf603e5b7f827dfabcb6d63bf0", @"/Views/_ViewImports.cshtml")]
    public class Views_LFBoat_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LFSail.Models.Boat>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
  
    ViewData["Title"] = "Delete Boat for " + ViewBag.FullName;
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(147, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(154, 17, false);
#line 8 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(171, 153, true);
            WriteLiteral("</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Boat</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(325, 45, false);
#line 16 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BoatClass));

#line default
#line hidden
            EndContext();
            BeginContext(370, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(414, 41, false);
#line 19 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BoatClass));

#line default
#line hidden
            EndContext();
            BeginContext(455, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(499, 46, false);
#line 22 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.HullColour));

#line default
#line hidden
            EndContext();
            BeginContext(545, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(589, 42, false);
#line 25 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.HullColour));

#line default
#line hidden
            EndContext();
            BeginContext(631, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(675, 46, false);
#line 28 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SailNumber));

#line default
#line hidden
            EndContext();
            BeginContext(721, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(765, 42, false);
#line 31 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SailNumber));

#line default
#line hidden
            EndContext();
            BeginContext(807, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(851, 46, false);
#line 34 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.HullLength));

#line default
#line hidden
            EndContext();
            BeginContext(897, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(941, 42, false);
#line 37 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.HullLength));

#line default
#line hidden
            EndContext();
            BeginContext(983, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1027, 44, false);
#line 40 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BoatType));

#line default
#line hidden
            EndContext();
            BeginContext(1071, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1115, 45, false);
#line 43 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BoatType.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1160, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1204, 42, false);
#line 46 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Member));

#line default
#line hidden
            EndContext();
            BeginContext(1246, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1290, 48, false);
#line 49 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Member.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1338, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1382, 57, false);
#line 52 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ParkingCodeNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(1439, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1483, 65, false);
#line 55 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ParkingCodeNavigation.ParkingCode));

#line default
#line hidden
            EndContext();
            BeginContext(1548, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1586, 211, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74c89283cf4f4d098568703695091381", async() => {
                BeginContext(1612, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1622, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "adc11337efc0453391b0fd1a0901aea6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 60 "G:\A-courses\MS web tech - 2230\A3\toSubmit\LFAssignment3\LFSail\LFSail\Views\LFBoat\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BoatId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1662, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1746, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed8ec2d8f5a24c2c98eb1d6bb7eb09ac", async() => {
                    BeginContext(1768, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1784, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1797, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LFSail.Models.Boat> Html { get; private set; }
    }
}
#pragma warning restore 1591
