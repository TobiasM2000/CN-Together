using CN_Together.Data;
using CN_Together.Data.Models;
using System.IO;

namespace CN_Together.Pages
{
    public partial class Index
    {
        private readonly string loginPage = "/login"; 
        

        protected override async Task OnInitializedAsync()
        {
            this.RoomManager.AddMassage(new Hint("test", 3, Data.Enums.Team.Blue));
            this.RoomManager.AddMassage(new Hint("test3", 3, Data.Enums.Team.Red));

        }

        private void OpenLoginPage()
        {
            this.NavigationManager.NavigateTo(this.loginPage);
        }

        private void ResetRoom()
        {

        }

        public async void UpdateView()
        {
            await this.InvokeAsync(() => { this.StateHasChanged(); });
        }
    }
}
