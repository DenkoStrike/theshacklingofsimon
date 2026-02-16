namespace TheShacklingOfSimon.Commands.Tile_Commands_and_temporary_Manager
{
	public class PreviousTileCommand : ICommand
	{
		private TileManager tileManager;

		public PreviousTileCommand(TileManager tileManager)
		{
			this.tileManager = tileManager;
		}

		public void Execute()
		{
			tileManager.PreviousTile();
		}
	}
}