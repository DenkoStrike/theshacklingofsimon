namespace TheShacklingOfSimon.Commands.Tile_Commands_and_temporary_Manager
{
	public class NextTileCommand : ICommand
	{
		private TileManager tileManager;

		public NextTileCommand(TileManager tileManager)
		{
			this.tileManager = tileManager;
		}

		public void Execute()
		{
			tileManager.NextTile();
		}
	}
}