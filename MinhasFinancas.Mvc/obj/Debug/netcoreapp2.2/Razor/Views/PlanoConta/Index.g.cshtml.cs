#pragma checksum "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f18f6b3b942669e5a0c560a6a1789e2f0cc70a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlanoConta_Index), @"mvc.1.0.view", @"/Views/PlanoConta/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PlanoConta/Index.cshtml", typeof(AspNetCore.Views_PlanoConta_Index))]
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
#line 1 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\_ViewImports.cshtml"
using MinhasFinancas.Mvc;

#line default
#line hidden
#line 2 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\_ViewImports.cshtml"
using MinhasFinancas.Mvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f18f6b3b942669e5a0c560a6a1789e2f0cc70a4", @"/Views/PlanoConta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99e8e21e91bfc27e6034a06291d27acde2fc755d", @"/Views/_ViewImports.cshtml")]
    public class Views_PlanoConta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MinhasFinancas.Domain.Entidades.Plano_Conta>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 38, true);
            WriteLiteral("\r\n<h3>Meus Planos de Contas</h3>\r\n\r\n\r\n");
            EndContext();
#line 6 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(133, 309, true);
            WriteLiteral(@"    <table class=""table table-bordered"">
        <thead>
            <tr style=""text-align:center"">
                <th>#</th>
                <th>#</th>
                <th>ID</th>
                <th>Descrição</th>
                <th>Tipo</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 19 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
              
                foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(522, 124, true);
            WriteLiteral("                    <tr style=\"text-align:center\">\r\n                        <td><button type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 646, "\"", 683, 3);
            WriteAttributeValue("", 656, "Editar(", 656, 7, true);
#line 23 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 663, item.Id.ToString(), 663, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 682, ")", 682, 1, true);
            EndWriteAttribute();
            BeginContext(684, 95, true);
            WriteLiteral(">Editar</button></td>\r\n                        <td><button type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 779, "\"", 817, 3);
            WriteAttributeValue("", 789, "Excluir(", 789, 8, true);
#line 24 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 797, item.Id.ToString(), 797, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 816, ")", 816, 1, true);
            EndWriteAttribute();
            BeginContext(818, 52, true);
            WriteLiteral(">Excluir</button></td>\r\n                        <td>");
            EndContext();
            BeginContext(871, 7, false);
#line 25 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
                       Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(878, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(914, 14, false);
#line 26 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
                       Write(item.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(928, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
            BeginContext(1042, 28, true);
            WriteLiteral("                        <td>");
            EndContext();
            BeginContext(1071, 20, false);
#line 28 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
                       Write(item.Tipo.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1091, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 30 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
                }
            

#line default
#line hidden
            BeginContext(1159, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
            BeginContext(1193, 124, true);
            WriteLiteral("    <button type=\"button\" class=\"btn btn-block btn-primary\" onclick=\"CriarPlanoConta()\">Criar novo Plano de Conta</button>\r\n");
            EndContext();
#line 36 "C:\Users\emmanuel.marinho\source\repos\MinhasFinancas\MinhasFinancas.Mvc\Views\PlanoConta\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1320, 581, true);
            WriteLiteral(@"<br />
<button type=""button"" class=""btn btn-block btn-primary"" onclick=""VoltarParaMenu()"">Voltar para menu principal</button>
<script>
    function CriarPlanoConta() {
        window.location.href = ""../PlanoConta/CriarPlanoConta"";
    }

    function Excluir(id_conta) {
        window.location.href = ""../PlanoConta/ExcluirPlanoConta/"" + id_conta;
    }
    function Editar(id_conta) {
        window.location.href = ""../PlanoConta/EditarPlanoConta/"" + id_conta;
    }
    function VoltarParaMenu() {
        window.location.href = ""../Home/Menu"";
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MinhasFinancas.Domain.Entidades.Plano_Conta>> Html { get; private set; }
    }
}
#pragma warning restore 1591
