namespace TheShacklingOfSimon.Commands;

public class SetSpriteCommand : ICommand
{
    private IEntity _entity;
    private int _id;

    public SetSpriteCommand(IEntity p, int id)
    {
        this._entity = p;
        this._id = id;
    }

    public void Execute()
    {
        _entity.SetSprite(_id);
    }
}