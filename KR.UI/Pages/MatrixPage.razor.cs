using KR.Domains.Interfaces;
using KR.Domains.Model;
using Microsoft.AspNetCore.Components;
using Refit;

namespace KR.UI.Pages
{
    public partial class MatrixPage : ComponentBase
    {
        private readonly IProcedureType procedureTypeService;

        private ProcedureType procedureTypeToCreate = new();
        private List<ProcedureType> procedureTypes = new();
        private List<ProcedureType> procedureTypesSource = new();
        private int? editItem = null;
        private string procedureName;

        public MatrixPage()
        {
            procedureTypeService = RestService.For<IProcedureType>("http://localhost:8080");
        }

        protected override async Task OnInitializedAsync()
        {
            procedureTypesSource = await procedureTypeService.Read(0, int.MaxValue);
            procedureTypes = procedureTypesSource;
            StateHasChanged();
        }

        private void Edit(int id)
        {
            editItem = id;
            StateHasChanged();
        }

        private async void Save(int id)
        {
            await procedureTypeService.Update(id, procedureTypes.First(pt => pt.Id == id));
            editItem = null;
            StateHasChanged();
        }

        private void Cancel()
        {
            editItem = null;
            StateHasChanged();
        }

        private void Find()
        {
            if (string.IsNullOrWhiteSpace(procedureName))
            {
                procedureTypes = procedureTypesSource;
            }
            else
            {
                procedureTypes = procedureTypesSource.Where(p => p.Name.ToLower().Contains(procedureName)).ToList();
            }
        }

        private async Task CreateNew()
        {
            await procedureTypeService.Create(procedureTypeToCreate);
            procedureTypeToCreate = new();
            procedureTypesSource = await procedureTypeService.Read(0, int.MaxValue);
            StateHasChanged();
        }
    }
}
