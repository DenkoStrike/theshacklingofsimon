namespace TheShacklingOfSimon.Controllers;

public interface IController<T>
{
    void Update();
    void RegisterCommand(T input, Commands.ICommand command);
}