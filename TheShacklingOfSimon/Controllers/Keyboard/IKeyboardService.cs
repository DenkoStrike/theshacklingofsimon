#region

using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Keyboard;

#endregion

namespace TheShacklingOfSimon.Controllers.Keyboard;

public interface IKeyboardService
{
    InputState GetKeyState(KeyboardButton button);
}