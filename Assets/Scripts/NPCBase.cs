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

        SetTarget(transform.position + (runDirection * _runDistance));
    }


    public void Init()
    {

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
