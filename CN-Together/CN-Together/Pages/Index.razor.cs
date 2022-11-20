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
            this.RoomManager.UpdateMessagesEvent += this.UpdateView;

        }

        private void OpenLoginPage()
        {
            this.NavigationManager.NavigateTo(this.loginPage);
        }

        private void ResetRoom()
        {
            this.RoomManager.ResetMessages();
        }

        public async void UpdateView()
        {
            await this.InvokeAsync(() => { this.StateHasChanged(); });
        }
    }
}
