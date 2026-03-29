#region

using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Mouse;

#endregion

namespace TheShacklingOfSimon.Controllers.Mouse;

public record struct MouseInput
{
    public readonly MouseInputRegion Region;
    public readonly InputState State;
    public readonly MouseButton Button;

    public MouseInput(MouseInputRegion region, InputState state, MouseButton button)
    {
        Region = region;
        State = state;
        Button = button;
    }
}