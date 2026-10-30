using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Soul : MonoBehaviour
{
    [SerializeField] private UnityEvent _collectEvent;
    [SerializeField] private Collider _collider;

    public void Collect()
    {
        _collider.enabled = false;
        _collectEvent.Invoke();
    }    

    public void Destory(float time)
    {
        StartCoroutine(DestroyAfter(time));
        
    }

    public void MoveTowardsPlayer(float time)
    {
        StartCoroutine(MoveTowardsPlayerOverTime(time));
    }

    IEnumerator MoveTowardsPlayerOverTime(float time)
    {
        Vector3 startPosition = transform.position;
        for (float currentTime = 0; currentTime < time; currentTime += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPosition, Globals.GetCurrentPlayer().transform.position, currentTime / time);

            yield return null;
        }

        
    }

    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
