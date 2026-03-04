using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Gamepad;

namespace TheShacklingOfSimon.Controllers.Gamepad;

public interface IGamepadService
{
    Vector2 GetLeftJoystickPosition();
    Vector2 GetRightJoystickPosition();
    InputState GetButtonState(GamepadButton button);
}