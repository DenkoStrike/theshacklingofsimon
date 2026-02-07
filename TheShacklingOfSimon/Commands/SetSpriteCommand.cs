namespace TheShacklingOfSimon.Commands;

public class SetSpriteCommand : ICommand
{
    private Game1 _game;
    private int _id;

    public SetSpriteCommand(Game1 game, int id)
    {
        this._game = game;
        this._id = id;
    }

    public void Execute()
    {
        _game.SetSprite(_id);
    }
}