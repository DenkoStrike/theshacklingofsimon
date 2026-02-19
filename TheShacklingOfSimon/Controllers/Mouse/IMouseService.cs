using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Mouse;

namespace TheShacklingOfSimon.Controllers.Mouse;

public interface IMouseService
{
    XYPoint GetPosition();
    InputState GetButtonState(MouseButton button);
}