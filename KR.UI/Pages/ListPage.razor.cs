using KR.Domains.Interfaces;
using KR.Domains.Model;
using Microsoft.AspNetCore.Components;
using Refit;

namespace KR.UI.Pages
{
    public partial class ListPage : ComponentBase
    {
        private readonly IProcedureType procedureTypeService;
        private int currentShift = 0;
        private int maxCount = 0;
        private ProcedureType currentProcedureType = new();

        private bool isNewCreating;

        public ListPage()
        {
            procedureTypeService = RestService.For<IProcedureType>("http://localhost:8080");
        }

        protected override async Task OnInitializedAsync()
        {
            maxCount = (await procedureTypeService.Read(0, int.MaxValue)).Count;
            currentProcedureType = await procedureTypeService.Read(currentShift);
            StateHasChanged();
        }

        private async Task ReadPrevious()
        {
            currentShift--;
            currentProcedureType = await procedureTypeService.Read(currentShift);
            StateHasChanged();
        }

        private async Task ReadNext()
        {
            currentShift++;
            currentProcedureType = await procedureTypeService.Read(currentShift);
            StateHasChanged();
        }

        private async Task Update()
        {
            await procedureTypeService.Update(currentProcedureType.Id, currentProcedureType);
            StateHasChanged();
        }

        private void StartCreatingNew()
        {
            isNewCreating = true;
            currentProcedureType = new();
            StateHasChanged();
        }

        private async Task CancelNewCreating()
        {
            isNewCreating = false;
            currentProcedureType = await procedureTypeService.Read(currentShift);
            StateHasChanged();
        }

        private async void SaveNew()
        {
            isNewCreating = false;
            await procedureTypeService.Create(currentProcedureType);
            currentProcedureType = await procedureTypeService.Read(currentShift);
            StateHasChanged();
        }
    }
}
