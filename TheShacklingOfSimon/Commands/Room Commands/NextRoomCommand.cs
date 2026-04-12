#region

using TheShacklingOfSimon.Rooms_and_Tiles.Rooms.RoomManager;

#endregion

namespace TheShacklingOfSimon.Commands.Room_Commands
{
    public sealed class NextRoomCommand : ICommand
    {
        private readonly RoomManager roomManager;

        public NextRoomCommand(RoomManager roomManager)
        {
            this.roomManager = roomManager;
        }

        public void Execute()
        {
            roomManager.NextRoom();
        }
    }
}