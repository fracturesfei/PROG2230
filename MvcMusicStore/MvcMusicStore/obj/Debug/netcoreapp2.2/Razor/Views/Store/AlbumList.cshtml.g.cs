#pragma checksum "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\Store\AlbumList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4ba85be94f377fb03bf968a166b949446359dca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_AlbumList), @"mvc.1.0.view", @"/Views/Store/AlbumList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Store/AlbumList.cshtml", typeof(AspNetCore.Views_Store_AlbumList))]
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
#line 1 "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\_ViewImports.cshtml"
using MvcMusicStore;

#line default
#line hidden
#line 2 "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\_ViewImports.cshtml"
using MvcMusicStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4ba85be94f377fb03bf968a166b949446359dca", @"/Views/Store/AlbumList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f3d7d6c215ab91880cc81299f2cd15c4126a9bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Store_AlbumList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MvcMusicStore.Models.Album>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\Store\AlbumList.cshtml"
  
    ViewData["Title"] = "Store Album List";
    Layout = "~/Views/Shared/Basesite.cshtml";

#line default
#line hidden
            BeginContext(148, 28, true);
            WriteLiteral("\r\n<h1>AlbumList</h1>\r\n<ul>\r\n");
            EndContext();
#line 9 "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\Store\AlbumList.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
            BeginContext(216, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(229, 10, false);
#line 11 "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\Store\AlbumList.cshtml"
       Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(239, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 12 "C:\Users\Fei\Desktop\MvcMusicStore\MvcMusicStore\Views\Store\AlbumList.cshtml"
    }

#line default
#line hidden
            BeginContext(253, 10, true);
            WriteLiteral("</ul>   \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MvcMusicStore.Models.Album>> Html { get; private set; }
    }
}
#pragma warning restore 1591
