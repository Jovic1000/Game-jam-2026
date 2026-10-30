using System;
using UnityEngine;
using UnityEngine.AI;

public class NPCBase : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Collider _detectionCollider;


    [SerializeField] private NPCStats _stats;


    [SerializeField] private float _runDistance;


    /*public enum AIState
    {
        NONE,
        IDLE,
        SCARED
    }*/
    //[SerializeField] private AIState _aiState;


    public void SetTarget(Vector3 targetPosition)
    {
        //if (_agent.destination == targetPosition) return;
        _agent.SetDestination(targetPosition);
    }


    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
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




    public void Kill()
    {

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Init();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
