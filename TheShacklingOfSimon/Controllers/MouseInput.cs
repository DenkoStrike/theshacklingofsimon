using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheShacklingOfSimon.Controllers;

public enum MouseButton
{
    Left,
    Right,
    Middle,
    Thumb1,
    Thumb2
}
public record struct MouseInput
{
    public Rectangle Region;
    public ButtonState State;
    public MouseButton Button;

    public MouseInput(Rectangle region, ButtonState state, MouseButton button)
    {
        Region = region;
        State = state;
        Button = button;
    }
}