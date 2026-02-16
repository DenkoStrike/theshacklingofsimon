namespace TheShacklingOfSimon.Commands.Item_Commands_and_Temporary_Manager
{
	public class PreviousItemCommand : ICommand
	{
		private ItemManager itemManager;

		public PreviousItemCommand(ItemManager itemManager)
		{
			this.itemManager = itemManager;
		}

		public void Execute()
		{
			itemManager.PreviousItem();
		}
	}
}