namespace TheShacklingOfSimon.Commands;

public class ExitCommand : ICommand
{
    private Game1 _game;

    public ExitCommand(Game1 game)
    {
        this._game = game;
    }

    public void Execute()
    {
        _game.Exit();
    }
}