using CN_Together.Data.Enums;
using CN_Together.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CN_Together.Pages
{
    public partial class HintPage
    {
        [Parameter] public string Color { get; set; } = string.Empty;

        public bool giveHint { get; set; } = false;
        private bool showContent { get; set; } = true;

        private string selectedNumber { get; set; } = "0";
        private string hint { get; set; } = "";
        private Hint EnemyHint { get; set; } = new Hint("Enemyteam i", string.Empty, Team.Blue);

        private Team team;

        protected override async Task OnInitializedAsync()
        {
            switch (this.Color)
            {
                case "blue":
                    this.team = Team.Blue;
                    this.RoomManager.HintReqestTeamFromRed += AccenpHintTeamRed;
                    this.RoomManager.AcceptHintRequestForBlue += AcceptedHintFromBlue;
                    break;
                case "red":
                    this.team = Team.Red;
                    this.RoomManager.HintReqestTeamFromBlue += AccenpHintTeamBlue;
                    this.RoomManager.AcceptHintRequestForRed += AcceptedHintFromRed;
                    break;
                default:
                    this.NavigateTo("/login");
                    break;
            }        

            Team beginningTeam = this.RoomManager.GetBeginningTeam();

            if (beginningTeam.Equals(this.team))
            {
                this.giveHint = true;
            }
            else
            {
                this.giveHint = false;
                this.showContent = false;
            }

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

        private void AcceptedHintFromBlue(bool b, Hint t)
        {
            this.Accepted(b);
        }
        private void AcceptedHintFromRed(bool b, Hint t)
        {
            this.Accepted(b);
        }

        private void Accepted(bool b)
        {
            if (b)
            {
                this.giveHint = false;
                this.showContent = false;
            }
            else
            {
                this.giveHint = true;
                this.showContent = true;
            }

            this.UpdateView();
        }

        private void AccenpHintTeamBlue(Hint t)
        {
            this.giveHint = false;
            this.showContent = true;
            this.EnemyHint = t;
            this.UpdateView();
        }

        private void AccenpHintTeamRed(Hint t)
        {
            this.giveHint = false;
            this.showContent = true;
            this.EnemyHint = t;
            this.UpdateView();
        }

        public void RequestHint()
        {
            this.RoomManager.RequestHint(new Hint(this.hint, this.selectedNumber, this.team));
            this.giveHint = false;
            this.showContent = false;
            this.UpdateView();
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
            this.showContent = true;
            this.UpdateView();
        }

        private void End()
        {
            this.giveHint = false;
            this.showContent = false;
            this.UpdateView();
        }

        public async void UpdateView()
        {
            await this.InvokeAsync(() => { this.StateHasChanged(); });
        }

        public void AcceptEnemyHint()
        {
            this.RoomManager.RequestAnswer(this.EnemyHint, true);
            this.showContent = true;
            this.giveHint = true;
            this.UpdateView();
        }

        public void DenyEnemyHint()
        {
            this.RoomManager.RequestAnswer(this.EnemyHint, false);
            this.showContent = false;
            this.giveHint = false;
            this.UpdateView();
        }

        private void NavigateTo(string path)
        {
            this.NavigationManager.NavigateTo(path);
        }
    }
}
