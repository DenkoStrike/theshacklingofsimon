using TheShacklingOfSimon.Tiles;

namespace TheShacklingOfSimon.Commands
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