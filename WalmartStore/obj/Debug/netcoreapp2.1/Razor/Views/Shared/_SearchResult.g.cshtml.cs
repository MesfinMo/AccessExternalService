#pragma checksum "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "745b9f855d63a7cf451466f1a7d5566cf973aefc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchResult), @"mvc.1.0.view", @"/Views/Shared/_SearchResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_SearchResult.cshtml", typeof(AspNetCore.Views_Shared__SearchResult))]
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
#line 1 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\_ViewImports.cshtml"
using WalmartStore;

#line default
#line hidden
#line 2 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\_ViewImports.cshtml"
using WalmartStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"745b9f855d63a7cf451466f1a7d5566cf973aefc", @"/Views/Shared/_SearchResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7879b2e97af4bcbd148e873c6b7fc7bed28f3a71", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AES.Domains.Service.SearchResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 50, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n");
            EndContext();
#line 5 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
          var i = 0; 

#line default
#line hidden
            BeginContext(115, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 6 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
         foreach (var product in Model.SearchProducts)
        {
            if(i % 4 == 0)
            {

#line default
#line hidden
            BeginContext(223, 25, true);
            WriteLiteral(" <div class=\"row\"></div> ");
            EndContext();
#line 9 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
                                      }

#line default
#line hidden
            BeginContext(251, 137, true);
            WriteLiteral("            <div class=\"col-md-3 product-name-search pull-left\">\r\n                <div class=\"card card-bg\">\r\n                    <div><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 388, "\"", 422, 2);
            WriteAttributeValue("", 395, "#", 395, 1, true);
#line 12 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
WriteAttributeValue("", 396, product.Product.ProductId, 396, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(423, 24, true);
            WriteLiteral(" id=\"productThumb\" ><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 447, "\"", 488, 1);
#line 12 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
WriteAttributeValue("", 453, product.Product.MediumThumbnailUri, 453, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(489, 17, true);
            WriteLiteral(" data-productId=\"");
            EndContext();
            BeginContext(507, 25, false);
#line 12 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
                                                                                                                                            Write(product.Product.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(532, 63, true);
            WriteLiteral("\" /></a></div>\r\n                    <div class=\"padding-top\"><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 595, "\"", 629, 2);
            WriteAttributeValue("", 602, "#", 602, 1, true);
#line 13 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
WriteAttributeValue("", 603, product.Product.ProductId, 603, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(630, 17, true);
            WriteLiteral(" data-productId=\"");
            EndContext();
            BeginContext(648, 25, false);
#line 13 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
                                                                                              Write(product.Product.ProductId);

#line default
#line hidden
            EndContext();
            BeginContext(673, 19, true);
            WriteLiteral("\" id=\"productName\">");
            EndContext();
            BeginContext(693, 27, false);
#line 13 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
                                                                                                                                           Write(product.Product.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(720, 52, true);
            WriteLiteral("</a></div>\r\n                    <div class=\"price\">$");
            EndContext();
            BeginContext(773, 21, false);
#line 14 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
                                   Write(product.Product.Price);

#line default
#line hidden
            EndContext();
            BeginContext(794, 56, true);
            WriteLiteral("</div>\r\n                    <div class=\"twodayshipping\">");
            EndContext();
            BeginContext(851, 30, false);
#line 15 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
                                           Write(product.Product.TwoDayShipping);

#line default
#line hidden
            EndContext();
            BeginContext(881, 52, true);
            WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 18 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_SearchResult.cshtml"
           
            i++;
        }

#line default
#line hidden
            BeginContext(975, 38, true);
            WriteLiteral("        \r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AES.Domains.Service.SearchResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
