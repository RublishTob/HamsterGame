using UnityEngine;

[CreateAssetMenu(fileName = "LevelViewConfig", menuName = "Config/levelView")]
public class LevelViewConfig : ScriptableObject
{
    [SerializeField] public int level;
    [SerializeField] public Sprite levelImage;
}
