#region

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Commands;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Gamepad;

#endregion

namespace TheShacklingOfSimon.Controllers.Gamepad;

public class GamepadController : IGamepadController
{
    private readonly IGamepadService _gamepadService;
    private readonly Dictionary<GamepadButtonInput, ICommand> _buttonMap;
    private readonly Dictionary<GamepadJoystickInput, ICommand> _joystickMap;

    private readonly Dictionary<GamepadButton, InputState> _previousButtonStates;
    private readonly Dictionary<GamepadJoystickInput, bool> _previousJoystickStates;

    public GamepadController(IGamepadService gamepadService)
    {
        _gamepadService = gamepadService;
        _buttonMap = new Dictionary<GamepadButtonInput, ICommand>();
        _joystickMap = new Dictionary<GamepadJoystickInput, ICommand>();

        _previousButtonStates = new Dictionary<GamepadButton, InputState>();
        foreach (GamepadButton btn in Enum.GetValues(typeof(GamepadButton)))
        {
            _previousButtonStates.Add(btn, InputState.Released);
        }

        _previousJoystickStates = new Dictionary<GamepadJoystickInput, bool>();
    }

    public void RegisterCommand(GamepadButtonInput input, ICommand cmd)
    {
        _buttonMap.TryAdd(input, cmd);
    }

    public void RegisterCommand(GamepadJoystickInput input, ICommand cmd)
    {
        bool success = _joystickMap.TryAdd(input, cmd);
        if (success)
        {
            _previousJoystickStates[input] = false;
        }
    }

    public void UnregisterCommand(GamepadButtonInput input)
    {
        _buttonMap.Remove(input);
    }

    public void UnregisterCommand(GamepadJoystickInput input)
    {
        _joystickMap.Remove(input);
        _previousJoystickStates.Remove(input);
    }

    public void ClearCommands()
    {
        _buttonMap.Clear();
        _joystickMap.Clear();
        _previousJoystickStates.Clear();
    }

    public void Update()
    {
        // we use snapshots so bindings can safely change while commands run.
        KeyValuePair<GamepadButtonInput, ICommand>[] buttonBindings = _buttonMap.ToArray();

        foreach (var entry in buttonBindings)
        {
            GamepadButtonInput input = entry.Key;
            ICommand command = entry.Value;

            InputState currentState = _gamepadService.GetButtonState(input.Button);
            InputState previousState = _previousButtonStates[input.Button];

            bool isJustPressed =
                currentState == InputState.Pressed &&
                previousState == InputState.Released;

            if (
                (input.State == InputState.Pressed && currentState == InputState.Pressed) ||
                (input.State == InputState.Released && currentState == InputState.Released) ||
                (input.State == InputState.JustPressed && isJustPressed)
            )
            {
                command.Execute();
                OnInputDetected?.Invoke(InputSchema.GamepadButton);
            }

            _previousButtonStates[input.Button] = currentState;
        }

        KeyValuePair<GamepadJoystickInput, ICommand>[] joystickBindings = _joystickMap.ToArray();

        foreach (var entry in joystickBindings)
        {
            GamepadJoystickInput input = entry.Key;
            ICommand command = entry.Value;

            Vector2 rawInput;
            switch (input.Stick)
            {
                case GamepadStick.Left:
                    rawInput = _gamepadService.GetLeftJoystickPosition();
                    break;
                case GamepadStick.Right:
                    rawInput = _gamepadService.GetRightJoystickPosition();
                    break;
                default:
                    rawInput = Vector2.Zero;
                    break;
            }

            if (!_previousJoystickStates.ContainsKey(input))
            {
                _previousJoystickStates[input] = false;
            }

            bool isInRegion = input.Region.Contains(rawInput);
            bool wasInRegion = _previousJoystickStates[input];
            bool isJustPressed = isInRegion && !wasInRegion;
            bool isJustReleased = !isInRegion && wasInRegion;

            if (
                (input.State == InputState.Pressed && isInRegion) ||
                (input.State == InputState.Released && isJustReleased) ||
                (input.State == InputState.JustPressed && isJustPressed)
            )
            {
                command.Execute();
                OnInputDetected?.Invoke(InputSchema.GamepadJoystick);
            }

            _previousJoystickStates[input] = isInRegion;
        }
    }

    public event Action<InputSchema> OnInputDetected;
}