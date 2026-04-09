using System;
using TheShacklingOfSimon.Input;

namespace TheShacklingOfSimon.Controllers;

public interface IController 
{
    void Update();
    void ClearCommands();
    event Action<InputSchema> OnInputDetected;
}