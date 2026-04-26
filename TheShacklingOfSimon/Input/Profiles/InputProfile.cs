using System.Collections.Generic;
using TheShacklingOfSimon.Controllers.Gamepad;
using TheShacklingOfSimon.Controllers.Keyboard;
using TheShacklingOfSimon.Controllers.Mouse;

namespace TheShacklingOfSimon.Input.Profiles;

public class InputProfile
{
    public Dictionary<PlayerAction, KeyboardInput> KeyboardMap { get; set; }
    public Dictionary<PlayerAction, MouseInput> MouseMap { get; set; }
    public Dictionary<PlayerAction, GamepadButtonInput> GamepadButtonMap { get; set; }
    public Dictionary<PlayerAction, GamepadJoystickInput> GamepadJoystickMap { get; set; }
}