using UnityEngine;
using UnityEngine.Events;

public class SoulCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent _collectEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Soul")) { SoulCollision(); other.GetComponent<Soul>().Collect(); }
    }

    private void SoulCollision()
    {
        _collectEvent.Invoke();
    }
}
