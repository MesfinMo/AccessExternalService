#pragma checksum "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_ErrorMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35895c8836dd8684af18a2369394be3643a57c86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ErrorMessage), @"mvc.1.0.view", @"/Views/Shared/_ErrorMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ErrorMessage.cshtml", typeof(AspNetCore.Views_Shared__ErrorMessage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35895c8836dd8684af18a2369394be3643a57c86", @"/Views/Shared/_ErrorMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7879b2e97af4bcbd148e873c6b7fc7bed28f3a71", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ErrorMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(25, 18, true);
            WriteLiteral("\r\n<div>\r\n    <div>");
            EndContext();
            BeginContext(44, 44, false);
#line 5 "C:\Employment\walmartlabs\AccessExternalService\WalmartStore\Views\Shared\_ErrorMessage.cshtml"
    Write(Html.DisplayFor(model => model.ErrorMessage));

#line default
#line hidden
            EndContext();
            BeginContext(88, 14, true);
            WriteLiteral("</div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591