using CN_Together.Data.Models;

namespace CN_Together.Data.Interfaces
{
    public interface IRoomManager
    {
        public List<Hint> Hints { get; set; }

        event RoomManager.Notify UpdateMessagesEvent;

        void AddMassage(Hint message);
        void ResetMessages();
    }
}
