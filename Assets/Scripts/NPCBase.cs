using System;
using UnityEngine;
using UnityEngine.AI;

public class NPCBase : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Collider _detection;

    [SerializeField] private float _runDistance;

    public void SetTarget(Vector3 targetPosition)
    {
        if (_agent.destination == targetPosition) return;
        _agent.SetDestination(targetPosition);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("hi");

        if (other.CompareTag("Player")) OnPlayerDetected(other);
    }

    public virtual void OnPlayerDetected(Collider player)
    {

        Vector3 runDirection = (transform.position - player.transform.position).normalized;

        SetTarget(transform.position + (runDirection * _runDistance));
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
