#pragma checksum "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "499a224f96119e2c8362508fc2c7b1b70290dc3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_Search), @"mvc.1.0.view", @"/Views/Test/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Test/Search.cshtml", typeof(AspNetCore.Views_Test_Search))]
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
#line 1 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\_ViewImports.cshtml"
using musicstore;

#line default
#line hidden
#line 2 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\_ViewImports.cshtml"
using musicstore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"499a224f96119e2c8362508fc2c7b1b70290dc3f", @"/Views/Test/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8476b7a92ec51594cf6cb82c626102379c098b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Fei\Desktop\PROG2230\musicstore\musicstore\Views\Test\Search.cshtml"
  
    ViewData["Title"] = "Search";
    Layout = "Getexample";

#line default
#line hidden
            BeginContext(72, 110, true);
            WriteLiteral("\r\n<h1>Search</h1>\r\n<table>\r\n    <tr>\r\n    <th>Artist</th>\r\n    <th>Title</th>\r\n    <th>Price</th>\r\n    </tr>\r\n");
            EndContext();
            BeginContext(335, 12, true);
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
