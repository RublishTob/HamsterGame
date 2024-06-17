using UnityEngine;

[CreateAssetMenu(fileName = "LevelListConfig", menuName = "Config/levellist")]
public class LevelsConfig : ScriptableObject
{
    [field: SerializeField] public LevelViewConfig[] levels;
}
