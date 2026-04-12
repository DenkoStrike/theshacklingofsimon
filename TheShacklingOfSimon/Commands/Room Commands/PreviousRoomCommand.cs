#region

using TheShacklingOfSimon.Rooms_and_Tiles.Rooms.RoomManager;

#endregion

namespace TheShacklingOfSimon.Commands.Room_Commands
{
    public sealed class PreviousRoomCommand : ICommand
    {
        private readonly RoomManager roomManager;

        public PreviousRoomCommand(RoomManager roomManager)
        {
            this.roomManager = roomManager;
        }

        public void Execute()
        {
            roomManager.PrevRoom();
        }
    }
}