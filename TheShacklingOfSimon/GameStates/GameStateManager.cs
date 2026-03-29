#region

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace TheShacklingOfSimon.GameStates;

public class GameStateManager
{
    private readonly Stack<IGameState> _states;

    public GameStateManager()
    {
        _states = new Stack<IGameState>();
    }

    public void AddState(IGameState state)
    {
        if (state == null)
        {
            return;
        }

        _states.Push(state);
        state.Enter();
    }

    public void RemoveTopState()
    {
        if (_states.Count == 0)
        {
            return;
        }

        _states.Peek().Exit();
        _states.Pop();

        // When we leave pause, we want the play state to reload its controls.
        if (_states.Count > 0)
        {
            _states.Peek().Enter();
        }
    }

    public void Clear()
    {
        while (_states.Count > 0)
        {
            _states.Peek().Exit();
            _states.Pop();
        }
    }

    public void Update(GameTime delta)
    {
        if (_states.Count == 0)
        {
            return;
        }

        _states.Peek().Update(delta);
    }

    public void Draw(SpriteBatch spriteBatch, bool drawOnlyTop = false)
    {
        if (_states.Count == 0)
        {
            return;
        }

        if (drawOnlyTop)
        {
            _states.Peek().Draw(spriteBatch);
            return;
        }

        IGameState[] statesArray = _states.ToArray();
        for (int i = statesArray.Length - 1; i >= 0; i--)
        {
            statesArray[i].Draw(spriteBatch);
        }
    }
}