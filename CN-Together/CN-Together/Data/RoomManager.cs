using CN_Together.Data.Enums;
using CN_Together.Data.Interfaces;
using CN_Together.Data.Models;

namespace CN_Together.Data
{
    public class RoomManager : IRoomManager
    {
        public List<Hint> Hints { get; set; } =  new List<Hint>();

        private Team teamGivesHint { get; set; } = Team.Red;

        public void AddMassage(Hint message)
        {
            if (message.Team.Equals(Team.Red)) //message from team red -> next round team blue
                this.TeamBlueTurn();
            else
                this.TeamRedTurn();

            this.Hints.Add(message);
            this.UpdateMessagesEvent?.Invoke();
        }

        public void ResetHints(Team beginningTeam)
        {
            this.teamGivesHint = beginningTeam;
            if (beginningTeam.Equals(Team.Red))
                this.TeamRedTurn();
            else
                this.TeamBlueTurn();

            this.Hints = new List<Hint>();
            this.UpdateMessagesEvent?.Invoke(); 
        }

        public Team GetBeginningTeam()
        {
            return this.teamGivesHint;
        }

        private void TeamRedTurn()
        {
            this.teamGivesHint= Team.Red;
            this.BlueEndRound?.Invoke();
            this.RedStartRound?.Invoke();
        }

        private void TeamBlueTurn()
        {
            this.teamGivesHint = Team.Blue;
            this.RedEndRound?.Invoke();
            this.BlueStartRound?.Invoke();
        }

        #region Events

        public delegate void Notify();

        public event Notify UpdateMessagesEvent;

        public event Notify RedStartRound;
        public event Notify RedEndRound;

        public event Notify BlueStartRound;
        public event Notify BlueEndRound;

        #endregion

    }
}
