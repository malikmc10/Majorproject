#pragma checksum "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\Home\MyChart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c48d901f96a9200c19c9ba182933f408c08b5c43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MyChart), @"mvc.1.0.view", @"/Views/Home/MyChart.cshtml")]
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
#line 1 "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\_ViewImports.cshtml"
using JPSBillPayment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\_ViewImports.cshtml"
using JPSBillPayment.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\_ViewImports.cshtml"
using JPSBillPayment.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\Home\MyChart.cshtml"
using System.Web.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c48d901f96a9200c19c9ba182933f408c08b5c43", @"/Views/Home/MyChart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cd728f832c4b8ed024df57110f89d112d733b26", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MyChart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Daniel\Downloads\JPSBillPayment\JPSBillPayment\Views\Home\MyChart.cshtml"
  
 new Chart(width: 500, height: 300)

            .AddTitle("Chart for languages")

                 .AddSeries(chartType: "column",

                   xValue: new[] { "ASP.NET", "HTML5", "C Language", "C++" },

                     yValues: new[] { "90", "100", "80", "70" })

                   .Write("png");


#line default
#line hidden
#nullable disable
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
