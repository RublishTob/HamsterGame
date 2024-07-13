using System.Collections;
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
        gameObject.SetActive(false);
    }
    public void StartCount()
    {
        gameObject.SetActive(true);
        StartCoroutine(Count());
    }
    private IEnumerator Count()
    {
        while (_seconds >= 0)
        {
            _seconds -= Time.deltaTime;
            _count.text = Mathf.RoundToInt(_seconds).ToString();
            yield return null;
        }
    }
}
