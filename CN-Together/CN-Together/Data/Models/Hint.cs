using CN_Together.Data.Enums;

namespace CN_Together.Data.Models
{
    public class Hint
    {
        public string Message { get; set; }
        public string Number { get; set; }
        public Team Team { get; set; }

        public Hint(string message, string number, Team team)
        {
            this.Message = message;
            this.Number = number;   
            this.Team = team;
        }
    }
}
