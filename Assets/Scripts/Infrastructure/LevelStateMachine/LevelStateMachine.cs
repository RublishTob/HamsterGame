using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelStateMachine : MonoBehaviour
{
    private LevelStateFactory _levelStateFactory;
    private LevelState _currentState;
    private Dictionary<Type, LevelState> _states;

    [Inject]
    public void Construct(LevelStateFactory levelStateFactory)
    {
        _levelStateFactory = levelStateFactory;

        _states = new Dictionary<Type, LevelState>()
        {
            [typeof(StartLevel)] = _levelStateFactory.Create<StartLevel>(),
            [typeof(PauseLevel)] = _levelStateFactory.Create<PauseLevel>(),
            [typeof(LevelWin)] = _levelStateFactory.Create<LevelWin>(),
            [typeof(LevelLoose)] = _levelStateFactory.Create<LevelLoose>()
        };
    }
    
    void Update()
    {
        if (_currentState != null)
        _currentState.Update();
    }
    public void SwichState<T>() where T : LevelState
    {
        _currentState.Exit();

        StartState<T>();
    }
    public void StartState<T>() where T : LevelState
    {
        _currentState = _states[typeof(T)];
        _currentState.Start();
    }
}
