#region

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Sprites.Factory;
using TheShacklingOfSimon.Sprites.Products;

#endregion

namespace TheShacklingOfSimon.GameStates.States;

public class PlayerDeadGameState : IGameState
{
    private readonly GameStateManager _stateManager;
    private readonly InputManager _inputManager;
    private readonly GraphicsDevice _graphicsDevice;
    private readonly IPlayer _player;
    
    private readonly Action _restartGame;
    private readonly Action _quitGame;

    private readonly ISprite _backgroundSprite;
    private readonly ISprite _gameOverSprite;
    private readonly ISprite _controlsSprite;

    public PlayerDeadGameState(
        GameStateManager stateManager, 
        InputManager inputManager,
        GraphicsDevice graphicsDevice, 
        IPlayer player, 
        Action restartGame, 
        Action quitGame)
    {
        _stateManager = stateManager;
        _inputManager = inputManager;
        _graphicsDevice = graphicsDevice;
        _player = player;
        _restartGame = () =>
        {
            restartGame?.Invoke();
            _stateManager.RemoveState();
        };
        _quitGame = quitGame;

        _backgroundSprite = SpriteFactory.Instance.CreateStaticSprite("1x1white")
            .WithFade(0.0f, 0.8f, 0.25f).
            WithDelay(1.5f);
        _gameOverSprite = SpriteFactory.Instance.CreateTextSprite("OptimusPrinceps", "YOU DIED")
            .WithFade(0.0f, 0.8f, 0.125f)
            .WithDelay(4.5f);
        _controlsSprite = SpriteFactory.Instance.CreateTextSprite("OptimusPrinceps", "Press R to restart, Q to quit.")
            .WithFade(0.0f, 0.8f, 0.125f)
            .WithDelay(6.5f);
    }
    
    public void Enter()
    {
        _inputManager.LoadDeadStateControls(_restartGame, _quitGame);
        
        // TODO: should play the infamous Dark Souls "you died" sound effect here
    }

    public void Exit()
    {
        // TODO: stop the sound effect here
    }

    public void Update(GameTime delta)
    {
        // For animation
        _player.Update(delta);
        _backgroundSprite.Update(delta);
        _gameOverSprite.Update(delta);
        _controlsSprite.Update(delta);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle screen = _graphicsDevice.Viewport.Bounds;

        Vector2 gameOverSize = _gameOverSprite.GetDimensions();
        Vector2 controlsSize = _controlsSprite.GetDimensions();

        Vector2 gameOverPos = new Vector2(
            (screen.Width - gameOverSize.X) * 0.5f,
            (screen.Height - gameOverSize.Y) * 0.5f
        );
        Vector2 controlsPos = new Vector2(
            (screen.Width - controlsSize.X) * 0.5f,
            gameOverPos.Y + controlsSize.Y + 30f
        );
        
        _backgroundSprite.Draw(spriteBatch, screen, Color.Black);
        _gameOverSprite.Draw(spriteBatch, gameOverPos, Color.Red);
        _controlsSprite.Draw(spriteBatch, controlsPos, Color.Red);
    }
}