#pragma checksum "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12b1a822eabec216e7b2b153c4f4f3d004c1a199"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index), @"mvc.1.0.view", @"/Views/Orders/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/Index.cshtml", typeof(AspNetCore.Views_Orders_Index))]
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
#line 1 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\_ViewImports.cshtml"
using RentalProduct.PL;

#line default
#line hidden
#line 2 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\_ViewImports.cshtml"
using RentalProduct.PL.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b1a822eabec216e7b2b153c4f4f3d004c1a199", @"/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31af901c8b9a4e3a7d4afe14c554bacfc8af7b9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentalProducts.DAL.Models.ViewModels.ViewModels>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:block; margin:0 auto "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 26, true);
            WriteLiteral("\r\n<h2 class=\"text-center\">");
            EndContext();
            BeginContext(83, 37, false);
#line 3 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
                   Write(Model.Customers.FirstOrDefault().Name);

#line default
#line hidden
            EndContext();
            BeginContext(120, 298, true);
            WriteLiteral(@"'s Orders</h2>
</br>
</br>

<table class=""table"">
    <thead>
        <tr>
            <th>Type</th>
            <th>Days</th>
            <th>Price</th>
            <th>LoyaltyPoint</th>
            <th>ProductName</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
         foreach (var item in Model.Orders)
        {

#line default
#line hidden
            BeginContext(474, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(535, 39, false);
#line 23 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(574, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(642, 39, false);
#line 26 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Days));

#line default
#line hidden
            EndContext();
            BeginContext(681, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(749, 40, false);
#line 29 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(789, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(857, 47, false);
#line 32 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.LoyaltyPoint));

#line default
#line hidden
            EndContext();
            BeginContext(904, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(972, 101, false);
#line 35 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
               Write(Html.DisplayFor(modelItem => Model.Products.Where(p => p.Id == item.ProductId).FirstOrDefault().Name));

#line default
#line hidden
            EndContext();
            BeginContext(1073, 46, true);
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
            EndContext();
#line 39 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1130, 128, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<div style=\"margin-bottom: 35px\">\r\n    <span class=\"lead\">\r\n        <input type=\"hidden\" id=\"inputValue\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1258, "\"", 1304, 1);
#line 44 "C:\Users\comp\Desktop\RentalProducts\RentalProducts\RentalProducts\RentalProduct.PL\Views\Orders\Index.cshtml"
WriteAttributeValue("", 1266, Model.Customers.FirstOrDefault().Name, 1266, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1305, 194, true);
            WriteLiteral(" />\r\n        <button style=\"display:block; margin:0 auto \" onclick=\"SaveExcel()\" type=\"submit\" class=\"btn btn-success\">\r\n            Download\r\n        </button>\r\n    </span>\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(1499, 98, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37e8a82c33c84006a360df8bad4061df", async() => {
                BeginContext(1581, 12, true);
                WriteLiteral("Back to Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1597, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RentalProducts.DAL.Models.ViewModels.ViewModels> Html { get; private set; }
    }
}
#pragma warning restore 1591