﻿using CN_Together.Data.Enums;
using CN_Together.Data.Models;

namespace CN_Together.Data.Interfaces
{
    public interface IRoomManager
    {
        public List<Hint> Hints { get; set; }

        event RoomManager.Notify UpdateMessagesEvent;
        event RoomManager.Notify RedStartRound;
        event RoomManager.Notify RedEndRound;
        event RoomManager.Notify BlueStartRound;
        event RoomManager.Notify BlueEndRound;

        void AddMassage(Hint message);
        void ResetHints(Team beginningTeam);
        Team GetBeginningTeam();
    }
}
