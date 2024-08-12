using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelView : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _transform;

    public List<LevelView> Levels;

    public List<TextView> AllTextes;

    [SerializeField] public Button ToGame;
    [SerializeField] public BackToMenu ButtonBack;

}
