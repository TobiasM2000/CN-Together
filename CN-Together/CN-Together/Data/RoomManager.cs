using CN_Together.Data.Interfaces;
using CN_Together.Data.Models;

namespace CN_Together.Data
{
    public class RoomManager : IRoomManager
    {
        public List<Hint> Hints { get; set; } =  new List<Hint>();

        public void AddMassage(Hint message)
        {
            this.Hints.Add(message);
            this.UpdateMessagesEvent?.Invoke();
        }

        public void ResetMessages()
        {
            this.Hints = new List<Hint>();
            this.UpdateMessagesEvent?.Invoke(); 
        }


        #region Events

        public delegate void Notify();

        public event Notify UpdateMessagesEvent;

        #endregion

    }
}
