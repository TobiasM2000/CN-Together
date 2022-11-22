using CN_Together.Data.Enums;
using Microsoft.AspNetCore.Components;

namespace CN_Together.Pages
{
    public partial class HintPage
    {
        [Parameter] public string Color { get; set; } = string.Empty;

        public bool giveHint { get; set; } = true;

        private string selectedNumber { get; set; } = "0";
        private string hint { get; set; } = "";

        private Team team;

        protected override async Task OnInitializedAsync()
        {
            if (this.Color.Equals("blue"))
                this.team = Team.Blue;
            else
                this.team = Team.Red;
        }

        public void GiveHint()
        {
            this.RoomManager.AddMassage(new Data.Models.Hint(this.hint, this.selectedNumber, this.team));
        }

        private void ChangeNumber(ChangeEventArgs e)
        {
            try
            {
                this.selectedNumber = e.Value.ToString();
            }
            catch
            {
                this.selectedNumber = "0";
            }

        }
        private void ChangeHint(ChangeEventArgs e)
        {
            try
            {
                this.hint = e.Value.ToString();
            }
            catch
            {
                this.hint = "0";
            }

        }
    }
}
