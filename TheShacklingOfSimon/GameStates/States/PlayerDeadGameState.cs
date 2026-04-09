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

    private ISprite _backgroundSprite;

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

        _backgroundSprite = SpriteFactory.Instance.CreateStaticSprite("1x1white").WithFade(0.0f, 0.55f, 0.25f);
    }
    
    public void Enter()
    {
        _inputManager.LoadDeadStateControls(_restartGame, _quitGame);
    }

    public void Exit()
    {
        
    }

    public void Update(GameTime delta)
    {
        // For animation
        _player.Update(delta);
        _backgroundSprite.Update(delta);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle screen = _graphicsDevice.Viewport.Bounds;
        _backgroundSprite.Draw(spriteBatch, screen, Color.Black);
    }
}