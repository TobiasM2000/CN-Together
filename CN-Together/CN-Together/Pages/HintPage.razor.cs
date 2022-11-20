using CN_Together.Data.Enums;
using Microsoft.AspNetCore.Components;

namespace CN_Together.Pages
{
    public partial class HintPage
    {
        [Parameter] public string Color { get; set; } = string.Empty;

        private Team team;

        protected override async Task OnInitializedAsync()
        {
            if (this.Color.Equals("blue"))
                this.team = Team.Blue;
            else
                this.team = Team.Red;
        }

        public void AddMassage()
        {
            this.RoomManager.AddMassage(new Data.Models.Hint("Hello", 1, this.team));
        }
    }
}
