using CN_Together.Data.Enums;
using Microsoft.AspNetCore.Components;

namespace CN_Together.Pages
{
    public partial class HintPage
    {
        [Parameter] public string Color { get; set; } = string.Empty;

        public bool giveHint { get; set; } = false;

        private string selectedNumber { get; set; } = "0";
        private string hint { get; set; } = "";

        private Team team;

        protected override async Task OnInitializedAsync()
        {
            if (this.Color.Equals("blue"))
                this.team = Team.Blue;
            if(this.Color.Equals("red"))
                this.team = Team.Red;
            //else exe

            Team beginningTeam = this.RoomManager.GetBeginningTeam();

            if (beginningTeam.Equals(this.team))
                this.giveHint = true;
            else
                this.giveHint = false;

                if (this.team.Equals(Team.Red))
            {
                this.RoomManager.RedStartRound += this.Start;
                this.RoomManager.RedEndRound += End;
            }
            else
            {
                this.RoomManager.BlueStartRound += this.Start;
                this.RoomManager.BlueEndRound += this.End;
            }
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

        private void Start()
        {
            this.giveHint = true;
            this.UpdateView();
        }

        private void End()
        {
            this.giveHint = false;
            this.UpdateView();
        }

        public async void UpdateView()
        {
            await this.InvokeAsync(() => { this.StateHasChanged(); });
        }
    }
}
