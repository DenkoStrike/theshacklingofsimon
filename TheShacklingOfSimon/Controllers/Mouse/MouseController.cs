using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Mouse;

namespace TheShacklingOfSimon.Controllers.Mouse;

public class MouseController : IController<MouseInput>
{
    private readonly IMouseService _mouseService;
    private readonly Dictionary<MouseInput, Commands.ICommand> _map;
    private readonly Dictionary<MouseButton, InputState> _prevStates;

    public MouseController(IMouseService service)
    {
        _mouseService = service;
        _prevStates = new Dictionary<MouseButton, InputState>();
        foreach (MouseButton btn in System.Enum.GetValues(typeof(MouseButton)))
        {
            _prevStates.Add(btn, InputState.Released);
        }

        _map = new Dictionary<MouseInput, Commands.ICommand>();
    }

    public void RegisterCommand(MouseInput input, Commands.ICommand cmd)
    {
        _map.TryAdd(input, cmd);
    }

    public void UnregisterCommand(MouseInput input)
    {
        _map.Remove(input);
    }

    public void ClearCommands()
    {
        _map.Clear();
    }

    public void Update()
    {
        Vector2 pos = _mouseService.GetPosition();

        // we use a snapshot here for the same reason as keyboard. (safely change binds)
        KeyValuePair<MouseInput, Commands.ICommand>[] bindings = _map.ToArray();

        foreach (KeyValuePair<MouseInput, Commands.ICommand> entry in bindings)
        {
            MouseInput inputDefinition = entry.Key;
            Commands.ICommand command = entry.Value;

            if (!inputDefinition.Region.ContainsPoint(pos.X, pos.Y))
            {
                continue;
            }

            InputState currentState = _mouseService.GetButtonState(inputDefinition.Button);
            InputState previousState = _prevStates[inputDefinition.Button];

            bool isJustPressed =
                currentState == InputState.Pressed &&
                previousState == InputState.Released;

            if (
                (inputDefinition.State == InputState.Pressed && currentState == InputState.Pressed) ||
                (inputDefinition.State == InputState.Released && currentState == InputState.Released) ||
                (inputDefinition.State == InputState.JustPressed && isJustPressed)
            )
            {
                command.Execute();
            }
        }

        // Update the previous states for the next Update() call
        foreach (MouseButton btn in System.Enum.GetValues(typeof(MouseButton)))
        {
            _prevStates[btn] = _mouseService.GetButtonState(btn);
        }
    }
}