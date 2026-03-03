using Microsoft.Xna.Framework;

namespace TheShacklingOfSimon.Controllers.Gamepad;

public record struct GamepadJoystickInput
{
    public readonly GamepadStick Stick;
    public JoystickInputRegion Region;

    public GamepadJoystickInput(GamepadStick stick, JoystickInputRegion region)
    {
        Stick = stick;
        Region = region;
    }
}