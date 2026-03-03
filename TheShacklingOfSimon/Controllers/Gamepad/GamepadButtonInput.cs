using TheShacklingOfSimon.Input;

namespace TheShacklingOfSimon.Controllers.Gamepad;

public record struct GamepadButtonInput
{
    public readonly InputState State;
    public readonly GamepadButton Button;

    public GamepadButtonInput(InputState state, GamepadButton button)
    {
        State = state;
        Button = button;
    }
}