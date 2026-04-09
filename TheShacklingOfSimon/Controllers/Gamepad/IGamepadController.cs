using System;
using TheShacklingOfSimon.Input;

namespace TheShacklingOfSimon.Controllers.Gamepad;

public interface IGamepadController : IController<GamepadButtonInput>, IController<GamepadJoystickInput>
{
    new void Update();
    new void ClearCommands();
    new event Action<InputSchema> OnInputDetected;
}