using TheShacklingOfSimon.Tiles;

namespace TheShacklingOfSimon.Commands
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