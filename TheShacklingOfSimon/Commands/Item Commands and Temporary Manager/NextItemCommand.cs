namespace TheShacklingOfSimon.Commands.Item_Commands_and_Temporary_Manager
{
	public class NextItemCommand : ICommand
	{
		private ItemManager itemManager;

		public NextItemCommand(ItemManager itemManager)
		{
			this.itemManager = itemManager;
		}

		public void Execute()
		{ 
			itemManager.NextItem();
		}
	}
}