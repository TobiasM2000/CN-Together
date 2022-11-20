namespace CN_Together.Pages
{
    public partial class TeamLogin
    {
        private string teamRedPage = "/team/red";
        private string teamBluepage = "/team/blue";
        private void JoinTeamRed()
        {
            this.NavigateTo(this.teamRedPage);
        }
        private void JoinTeamBlue()
        {
            this.NavigateTo(this.teamBluepage);
        }

        private void NavigateTo(string path)
        {
            this.NavigationManager.NavigateTo(path);
        }
    }
}
