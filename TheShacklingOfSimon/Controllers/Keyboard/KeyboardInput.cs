using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Keyboard;
using TheShacklingOfSimon.Input.Mouse;

namespace TheShacklingOfSimon.Controllers.Keyboard;

public record struct KeyboardInput
{
    public InputState State;
    public KeyboardButton Button;

    public KeyboardInput(InputState state, KeyboardButton button)
    {
        State = state;
        Button = button;
    }
}