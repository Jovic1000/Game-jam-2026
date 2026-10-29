using UnityEngine;
using UnityEngine.Events;

public class MenuInstance : MonoBehaviour
{

    [SerializeField] private Canvas _canvas;

    [SerializeField] private UnityEvent _enableEvent;
    [SerializeField] private UnityEvent _disableEvent;



    void Awake()
    {
        if (!_canvas) _canvas = GetComponent<Canvas>();
    }

    public void Enable()
    {
        _enableEvent.Invoke();
        _canvas.enabled = true;
    }
    public void Disable()
    {
        _disableEvent.Invoke();
        _canvas.enabled = false;
    }

    public void SetEnabled(bool enabled)
    {
        if (enabled) _enableEvent.Invoke();
        else _disableEvent.Invoke();
        _canvas.enabled = enabled;
    }

    public bool Enabled()
    {
        return _canvas.enabled;
    }

    /*// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
