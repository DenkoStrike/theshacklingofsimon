#region

using TheShacklingOfSimon.Commands;

#endregion

namespace TheShacklingOfSimon.Controllers;

// For the generic methods
public interface IController<T> : IController
{
    void RegisterCommand(T input, ICommand command);
    void UnregisterCommand(T input);
}
 