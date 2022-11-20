using CN_Together.Data.Enums;

namespace CN_Together.Data.Models
{
    public class Hint
    {
        public string Message { get; set; }
        public int Number { get; set; }
        public Team Team { get; set; }

        public Hint(string message, int number, Team team)
        {
            this.Message = message;
            this.Number = number;   
            this.Team = team;
        }
    }
}
