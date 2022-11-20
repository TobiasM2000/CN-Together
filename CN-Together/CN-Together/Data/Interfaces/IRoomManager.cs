using CN_Together.Data.Models;

namespace CN_Together.Data.Interfaces
{
    public interface IRoomManager
    {
        public List<Hint> Hints { get; set; }

        void AddMassage(Hint message);
    }
}
