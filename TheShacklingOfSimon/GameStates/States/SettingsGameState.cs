using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Controllers.Mouse;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Mouse;
using TheShacklingOfSimon.Sprites.Factory;
using TheShacklingOfSimon.Sprites.Products;

namespace TheShacklingOfSimon.GameStates.States;

public class SettingsGameState : IGameState
{
    private readonly GameStateManager _stateManager;
    private readonly InputManager _inputManager;
    private readonly GraphicsDevice _graphicsDevice;
    private readonly Action _quitGame;

    private readonly ISprite _backgroundSprite;
    private readonly ISprite _backSprite;
    // TODO: Add a volume control sprite here

    public SettingsGameState(GameStateManager stateManager, InputManager inputManager, GraphicsDevice graphicsDevice, Action quitGame)
    {
        _stateManager = stateManager;
        _inputManager = inputManager;
        _graphicsDevice = graphicsDevice;
        _quitGame = quitGame;
        
        _backgroundSprite = SpriteFactory.Instance.CreateStaticSprite("1x1white")
            .WithTint(Color.Black);
        _backSprite = SpriteFactory.Instance.CreateTextSprite("Upheaval32", "BACK");
        // TODO: Add a volume control sprite here
    }

    public void Enter()
    {
        _inputManager.ClearAllControls();
        _inputManager.LoadDefaultSettingsControls(_quitGame);
        Dictionary<MouseInput, Action> guiControls = new Dictionary<MouseInput, Action>();
        
        Rectangle screen = _graphicsDevice.Viewport.Bounds;
        Vector2 backSize = _backSprite.GetDimensions();
        Vector2 backPos = new Vector2(5, screen.Height - backSize.Y - 5);
        
        guiControls.Add(
            new MouseInput(
                new MouseInputRegion(
                    backPos.X,
                    backPos.Y,
                    backSize.X,
                    backSize.Y
                ),
                InputState.JustPressed,
                MouseButton.Left
            ),
            _stateManager.RemoveState
        );
        
        // TODO: Add mute button click control here
        
        _inputManager.LoadGUIControls(guiControls);
    }

    public void Exit()
    {
    }

    public void Update(GameTime delta)
    {
        _backgroundSprite.Update(delta);
        _backSprite.Update(delta);
        // TODO: Update volume control sprite here
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle screen = _graphicsDevice.Viewport.Bounds;
        Vector2 backSize = _backSprite.GetDimensions();
        Vector2 backPos = new Vector2(5, screen.Height - backSize.Y - 5);
        
        _backgroundSprite.Draw(spriteBatch, screen, Color.White);
        _backSprite.Draw(spriteBatch, backPos, Color.White);
        // TODO: Draw volume control sprite here
    }
}