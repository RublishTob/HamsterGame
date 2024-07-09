using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _seconds;
    private TMP_Text _count;
    public float Seconds { get { return _seconds; } }

    private void Start()
    {
        _count = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        _seconds -= Time.deltaTime;
        _count.text = Mathf.RoundToInt(_seconds).ToString();
    }
}
