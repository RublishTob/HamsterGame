using System;
using UnityEngine;
using Zenject;

public class GameStateWacher : MonoBehaviour
{
    public event Action StateChanged;
    private GameStateMachineService _gameStateMachineService;
    private SoundMenuPresenter _soundMenuPresenter;

    [Inject]
    public void Construct(GameStateMachineService gameStateMachineService, SoundMenuPresenter soundMenuPresenter)
    {
        _gameStateMachineService = gameStateMachineService;
        _gameStateMachineService.GameStateWacher = this;
        _soundMenuPresenter = soundMenuPresenter;
    }
    private void OnDistroy()
    {
        _gameStateMachineService.GameStateWacher = null;
    }
    public void ChangeState()
    {
        _soundMenuPresenter.Disable();
    }
}
