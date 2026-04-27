#region

using TheShacklingOfSimon.UI;

#endregion

namespace TheShacklingOfSimon.Commands;

public class ToggleFogOfWarCommand : ICommand
{
    private readonly HUD _hud;

    public ToggleFogOfWarCommand(HUD hud)
    {
        _hud = hud;
    }

    public void Execute()
    {
        // This flips the true/false value of the fogofwar field
        _hud.IsFogOfWarActive = !_hud.IsFogOfWarActive;
    }
}