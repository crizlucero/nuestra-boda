#pragma checksum "C:\Users\Christian.Lucero\Documents\Personal\nuestra-boda\nuestra-boda\nuestra-boda.Web\Views\Admin\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c1f2b4213ecf40cd610ea844a99dbc55b87abba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Login), @"mvc.1.0.view", @"/Views/Admin/Login.cshtml")]
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
#line 1 "C:\Users\Christian.Lucero\Documents\Personal\nuestra-boda\nuestra-boda\nuestra-boda.Web\Views\_ViewImports.cshtml"
using nuestra_boda.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Christian.Lucero\Documents\Personal\nuestra-boda\nuestra-boda\nuestra-boda.Web\Views\_ViewImports.cshtml"
using nuestra_boda.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c1f2b4213ecf40cd610ea844a99dbc55b87abba", @"/Views/Admin/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfc182e2ad0ada2d2983c741590bad724762dc4a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<nuestra_boda.Core.Models.Users.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Christian.Lucero\Documents\Personal\nuestra-boda\nuestra-boda\nuestra-boda.Web\Views\Admin\Login.cshtml"
  
    ViewData["Title"] = "Inicio de Sesión";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Inicio de Sesión</h1>\r\n\r\n<div>\r\n    <h4>Iniciar sesión</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Christian.Lucero\Documents\Personal\nuestra-boda\nuestra-boda\nuestra-boda.Web\Views\Admin\Login.cshtml"
       Write(Html.TextBoxFor(model => model.Email, new { @class = "form-control", @placeholder = "Correo electrónico" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Christian.Lucero\Documents\Personal\nuestra-boda\nuestra-boda\nuestra-boda.Web\Views\Admin\Login.cshtml"
       Write(Html.PasswordFor(model => model.Password, new { @class = "form-control", @placeholder = "Contraseña" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <button id=\"btnLogin\" class=\"btn btn-light\">Acceder</button>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<nuestra_boda.Core.Models.Users.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
