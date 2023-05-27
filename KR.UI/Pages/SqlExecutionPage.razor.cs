using KR.Domains.Interfaces;
using KR.Domains.Model;
using Microsoft.AspNetCore.Components;
using Refit;

namespace KR.UI.Pages
{
    public partial class SqlExecutionPage : ComponentBase
    {
        private readonly IProcedureType procedureTypeService;

        private List<ProcedureType> procedureTypes = new();
        private string sqlScript;

        public SqlExecutionPage()
        {
            procedureTypeService = RestService.For<IProcedureType>("http://localhost:8080");
        }

        private async Task ExecuteScript()
        {
            procedureTypes = await procedureTypeService.ReadWithScript(sqlScript);
            StateHasChanged();
        }
    }
}
