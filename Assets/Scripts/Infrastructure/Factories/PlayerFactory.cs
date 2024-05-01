using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public GameObject Create()
    {
        var playerLoad = Resources.Load("Humster");
        return (GameObject)playerLoad;
    }
}
