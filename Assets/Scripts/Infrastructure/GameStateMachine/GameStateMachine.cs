using System;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private GameState _currentState;
    private GameStateFactory _gameStateFactory;
    private Dictionary<Type, GameState> _states;

    public GameState CurrentState { get { return _currentState; } }

    [Inject]
    public void Construct(GameStateFactory factory)
    {
        _gameStateFactory = factory;
        _states = new Dictionary<Type, GameState>()
        {
            [typeof(InitializeGame)] = _gameStateFactory.Create<InitializeGame>(),
            [typeof(Menu)] = _gameStateFactory.Create<Menu>(),
            [typeof(LoadLevelState)] = _gameStateFactory.Create<LoadLevelState>(),
            [typeof(GameLoopState)] = _gameStateFactory.Create<GameLoopState>(),
            [typeof(ShopState)] = _gameStateFactory.Create<ShopState>()
        };
        StartState<InitializeGame>();
    }

    public void SwichState<T>() where T: GameState
    {
        _currentState.Exit();

        StartState<T>();
    }
    private void StartState<T>() where T : GameState
    {
        _currentState = _states[typeof(T)];
        _currentState.Start();
    }

    private void Update()
    {
        _currentState.Update();
    }
}
