using System.Collections;
using UnityEngine;
using System;
using System.Threading.Tasks;


public class TutorialLevel : LevelState
{
    private Counter _counter;
    private TutorialText _tutorialText;
    private LevelStateMachine _stateMachine;
    public TutorialLevel(LevelStateMachine stateMachine, Counter counter, TutorialText tutorialText) : base(stateMachine)
    {
        _stateMachine = stateMachine;
        _counter = counter;
        _tutorialText = tutorialText;
    }

    public override void Exit()
    {
        _tutorialText.Hide();
        _counter.StartCount();
    }

    public async override void Start()
    {
        _tutorialText.Print();
        await Task.Delay(4000);
        _stateMachine.SwichState<StartLevel>();
    }

    public override void Update()
    {
    }

}
