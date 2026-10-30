using UnityEngine;
using UnityEngine.AI;

public class PlayerDetection : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Collider _detectionCollider;


    [SerializeField] private NPCStats _stats;


    [SerializeField] private float _runDistance;


    public void SetTarget(Vector3 targetPosition)
    {
        _agent.SetDestination(targetPosition);
    }


    private void OnTriggerStay(Collider other)
    {
        // checks if the collider is the player
        if (other.CompareTag("Player")) OnPlayerDetected(other);
    }


    public virtual void OnPlayerDetected(Collider player)
    {
        Vector3 runDirection = (transform.position - player.transform.position).normalized;

        SetTarget(transform.position + (runDirection * _stats.runDistance));
    }


    public void Init()
    {
        _agent.speed = _stats.moveSpeed;

        if (_detectionCollider.GetType() == typeof(SphereCollider))
        {
            SphereCollider sc = (SphereCollider)_detectionCollider;
            sc.radius = _stats.detectionRadius;
        }
        // Add code for other colldiers
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Init();
    }
}
