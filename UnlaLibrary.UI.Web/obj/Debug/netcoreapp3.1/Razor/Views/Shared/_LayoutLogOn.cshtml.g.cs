#pragma checksum "C:\Users\crist\source\repos\UnlaLibrary\UnlaLibrary.UI.Web\Views\Shared\_LayoutLogOn.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9608bb1ae7d89649f978dddf02612492bd5a5aa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutLogOn), @"mvc.1.0.view", @"/Views/Shared/_LayoutLogOn.cshtml")]
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
#line 1 "C:\Users\crist\source\repos\UnlaLibrary\UnlaLibrary.UI.Web\Views\_ViewImports.cshtml"
using UnlaLibrary.UI.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\crist\source\repos\UnlaLibrary\UnlaLibrary.UI.Web\Views\_ViewImports.cshtml"
using UnlaLibrary.UI.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9608bb1ae7d89649f978dddf02612492bd5a5aa9", @"/Views/Shared/_LayoutLogOn.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cb735b7c684cab46023e2b3cb38094ca165f82c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutLogOn : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9608bb1ae7d89649f978dddf02612492bd5a5aa93322", async() => {
                WriteLiteral(@"

    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>UNLa Library | Inicio</title>
    <link rel=""stylesheet"" href=""home_user.css"" />
    <link rel=""stylesheet"" href=""common.css"" />
    <link rel=""icon"" href=""/images/icono.png"" />
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css"" rel=""stylesheet""
          integrity=""sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6"" crossorigin=""anonymous"">
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"">
    <link href=""https://fonts.googleapis.com/css2?family=Raleway:wght@100;300;400;500;700&display=swap""
          rel=""stylesheet"">
    <link href=""https://fonts.googleapis.com/css2?family=Anton&display=swap"" rel=""stylesheet"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"" />
    <link");
                BeginWriteAttribute("href", " href=\"", 1046, "\"", 1088, 1);
#nullable restore
#line 19 "C:\Users\crist\source\repos\UnlaLibrary\UnlaLibrary.UI.Web\Views\Shared\_LayoutLogOn.cshtml"
WriteAttributeValue("", 1053, Url.Content("~/css/home_user.css"), 1053, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 1136, "\"", 1175, 1);
#nullable restore
#line 20 "C:\Users\crist\source\repos\UnlaLibrary\UnlaLibrary.UI.Web\Views\Shared\_LayoutLogOn.cshtml"
WriteAttributeValue("", 1143, Url.Content("~/css/common.css"), 1143, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9608bb1ae7d89649f978dddf02612492bd5a5aa96250", async() => {
                WriteLiteral(@"

    <nav class=""navbar navbar-expand-lg navbar-dark bg-dark"">
        <div class=""container-fluid w-75r"">
            <a class=""navbar-brand"" href=""#"">
                <img class=""logo"" src=""/images/logo.png"" />
            </a>
            <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#navbarText""
                    aria-controls=""navbarText"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                <span class=""navbar-toggler-icon""></span>
            </button>
            <div class=""collapse navbar-collapse"" id=""navbarText"">
                <ul class=""navbar-nav me-auto mb-2 mb-lg-0"">
                    <li class=""nav-item"">
                        <a class=""nav-link"" aria-current=""page"" href=""#"">Home</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link active"" aria-current=""page"" href=""#"">Catálogo</a>
                    </li>
                    <li class=""nav-item"">");
                WriteLiteral(@"
                        <a class=""nav-link"" href=""#"">Materias</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""#"">Contacto</a>
                    </li>
                </ul>
                <div class=""btn-group"">
                    <button class=""btn btn-outline-light me-2 rounded"" type=""button"" data-bs-toggle=""dropdown""
                            aria-expanded=""false"">
                        Nombre Apellido
                    </button>
                    <ul class=""dropdown-menu dropdown-menu-dark"">
                        <li><a class=""dropdown-item"" href=""#"">Cuenta</a></li>
                        <li><a class=""dropdown-item"" href=""#"">Favoritos</a></li>
                        <li><a class=""dropdown-item"" href=""index.html"">Salir</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
    ");
#nullable restore
#line 62 "C:\Users\crist\source\repos\UnlaLibrary\UnlaLibrary.UI.Web\Views\Shared\_LayoutLogOn.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
