namespace TheShacklingOfSimon.Commands.Item_Commands_and_Temporary_Manager
{
	public class DropItemCommand : ICommand
	{
		private ItemManager itemManager;

		public DropItemCommand(ItemManager itemManager)
		{
			this.itemManager = itemManager;
		}

		public void Execute()
		{ 
			itemManager.DropItem();
		}
	}
}