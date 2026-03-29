#region

using TheShacklingOfSimon.Commands;

#endregion

namespace TheShacklingOfSimon.Controllers;

public interface IController<T>
{
    void ClearCommands();
    void Update();
    void RegisterCommand(T input, ICommand command);
    void UnregisterCommand(T input);
}
 