using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BasicTrigger : MonoBehaviour
{
    public string[] _tagFilter;

    public UnityEvent _onTriggerEnter;
    public UnityEvent _onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (_tagFilter != null && _tagFilter.Contains(other.tag))
        {
            return;
        }


        _onTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_tagFilter != null && _tagFilter.Contains(other.tag))
        {
            return;
        }


        _onTriggerExit.Invoke();
    }
}
