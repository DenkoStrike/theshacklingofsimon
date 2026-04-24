#region

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using TheShacklingOfSimon.Controllers.Mouse;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Mouse;
using TheShacklingOfSimon.Sounds;
using TheShacklingOfSimon.Sprites.Factory;
using TheShacklingOfSimon.Sprites.Products;

#endregion

namespace TheShacklingOfSimon.GameStates.States;

public class PauseGameState : IGameState
{
    private readonly GameStateManager _stateManager;
    private readonly InputManager _inputManager;
    private readonly GraphicsDevice _graphicsDevice;
    private readonly Action _quitGame;

    private readonly ISprite _backgroundSprite;
    private readonly ISprite _pauseSprite;
    private readonly ISprite _resumeSprite;
    private readonly ISprite _settingsSprite;
    private readonly ISprite _quitSprite;

    public PauseGameState(
        GameStateManager stateManager,
        InputManager inputManager,
        GraphicsDevice graphicsDevice,
        Action quitGame)
    {
        _stateManager = stateManager;
        _inputManager = inputManager;
        _graphicsDevice = graphicsDevice;
        _quitGame = quitGame;

        _backgroundSprite = SpriteFactory.Instance.CreateStaticSprite("1x1white")
            .WithTint(Color.Black);
        _pauseSprite = SpriteFactory.Instance.CreateTextSprite("OptimusPrinceps28", "PAUSED");
        _resumeSprite = SpriteFactory.Instance.CreateTextSprite("OptimusPrinceps16", "RESUME");
        _settingsSprite = SpriteFactory.Instance.CreateTextSprite("OptimusPrinceps16", "SETTINGS");
        _quitSprite = SpriteFactory.Instance.CreateTextSprite("OptimusPrinceps16", "QUIT");
    }

    public void Enter()
    {
        _inputManager.ClearAllControls();
        _inputManager.LoadPauseControls(
            onResumeRequested: () => _stateManager.RemoveState(),
            onQuitRequested: _quitGame);
        
        Rectangle screen = _graphicsDevice.Viewport.Bounds;
        Vector2 pausedSize = _pauseSprite.GetDimensions();
        Vector2 resumeSize = _resumeSprite.GetDimensions();
        Vector2 settingsSize = _settingsSprite.GetDimensions();
        Vector2 quitSize = _quitSprite.GetDimensions();
        
        Vector2 pausedPos = new Vector2(
            (screen.Width - pausedSize.X) * 0.5f,
            (screen.Height - pausedSize.Y) * 0.5f
        );
        Vector2 resumePos = new Vector2(
            (screen.Width - resumeSize.X) * 0.5f,
            pausedPos.Y + resumeSize.Y + 30f
        );
        Vector2 settingsPos = new Vector2(
            (screen.Width - settingsSize.X) * 0.5f,
            resumePos.Y + settingsSize.Y + 30f
        );
        Vector2 quitPos = new Vector2(
            (screen.Width - quitSize.X) * 0.5f,
            settingsPos.Y + quitSize.Y + 30f
        );
        
        Dictionary<MouseInput, Action> guiControls = new Dictionary<MouseInput, Action>();
        
        guiControls.Add(
            new MouseInput(
                new MouseInputRegion(
                    resumePos.X,
                    resumePos.Y,
                    resumeSize.X,
                    resumeSize.Y
                ),
                InputState.JustPressed,
                MouseButton.Left
            ),
            _stateManager.RemoveState
        );
        
        guiControls.Add(
            new MouseInput(
                new MouseInputRegion(
                    settingsPos.X,
                    settingsPos.Y,
                    settingsSize.X,
                    settingsSize.Y
                ),
                InputState.JustPressed,
                MouseButton.Left
            ),
            () => _stateManager.AddState(
                new SettingsGameState(
                    _stateManager,
                    _inputManager,
                    _graphicsDevice,
                    _quitGame
                )
            )
        );
        guiControls.Add(
            new MouseInput(
                new MouseInputRegion(
                    quitPos.X, 
                    quitPos.Y, 
                    quitSize.X, 
                    quitSize.Y
                ),
                InputState.JustPressed,
                MouseButton.Left
            ),
            _quitGame
        );
        
        _inputManager.LoadGUIControls(guiControls);
        
        MediaPlayer.Pause();
        SoundManager.Instance.StopAllSFX();
    }

    public void Exit()
    {
        MediaPlayer.Resume();
    }

    public void Update(GameTime delta)
    {
        _backgroundSprite.Update(delta);
        _pauseSprite.Update(delta);
        _settingsSprite.Update(delta);
        _quitSprite.Update(delta);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle screen = _graphicsDevice.Viewport.Bounds;
        
        Vector2 pausedSize = _pauseSprite.GetDimensions();
        Vector2 resumeSize = _resumeSprite.GetDimensions();
        Vector2 settingsSize = _settingsSprite.GetDimensions();
        Vector2 quitSize = _quitSprite.GetDimensions();
        
        Vector2 pausedPos = new Vector2(
            (screen.Width - pausedSize.X) * 0.5f,
            (screen.Height - pausedSize.Y) * 0.5f
        );
        Vector2 resumePos = new Vector2(
            (screen.Width - resumeSize.X) * 0.5f,
            pausedPos.Y + resumeSize.Y + 30f
        );
        Vector2 settingsPos = new Vector2(
            (screen.Width - settingsSize.X) * 0.5f,
            resumePos.Y + settingsSize.Y + 30f
        );
        Vector2 quitPos = new Vector2(
            (screen.Width - quitSize.X) * 0.5f,
            settingsPos.Y + quitSize.Y + 30f
        );
        
        _backgroundSprite.Draw(spriteBatch, screen, Color.White);
        _pauseSprite.Draw(spriteBatch, pausedPos, Color.White);
        _resumeSprite.Draw(spriteBatch, resumePos, Color.White);
        _settingsSprite.Draw(spriteBatch, settingsPos, Color.White);
        _quitSprite.Draw(spriteBatch, quitPos, Color.White);
    }
}