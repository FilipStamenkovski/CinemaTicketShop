#pragma checksum "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a217027a3616a7772aa0c633ed99f444320cde2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
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
#line 1 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\_ViewImports.cshtml"
using Cinema.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\_ViewImports.cshtml"
using Cinema.Domain.DomainModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a217027a3616a7772aa0c633ed99f444320cde2", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"854e120be80c6363060b9bcafef6271dff0004bc", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Cinema.Domain.DomainModels.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"m-3\">\r\n        <a class=\"btn btn-success\">Order for: ");
#nullable restore
#line 10 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
                                         Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </div>\r\n\r\n");
#nullable restore
#line 13 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
     for (int i = 0; i < Model.TicketInOrders.Count; i++)
    {
        var item = Model.TicketInOrders.ElementAt(i).SelectedTicket;
        var quantity = Model.TicketInOrders.ElementAt(i).Quantity;

        if (i % 3 == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 21 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
            }



#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3 m-4\">\r\n                <div class=\"card\" style=\"width: 18rem; height: 35rem;\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 721, "\"", 743, 1);
#nullable restore
#line 26 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
WriteAttributeValue("", 727, item.MovieImage, 727, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 50%\" alt=\"Image for movie!\" />\r\n\r\n                    <div class=\"card-body\">\r\n                        <h3 class=\"card-title\">");
#nullable restore
#line 29 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
                                          Write(item.MovieName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 30 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
                                        Write(item.MovieGenre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 31 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
                                        Write(item.MovieTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <h6>Price: ");
#nullable restore
#line 32 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
                              Write(item.MoviePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <br /><h6>Quantity: ");
#nullable restore
#line 33 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
                                       Write(quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 38 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"



            if (i % 3 == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 44 "C:\Users\dewiqPC\source\repos\CinemaApplication\Cinema\Cinema.Web\Views\Order\Details.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cinema.Domain.DomainModels.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
