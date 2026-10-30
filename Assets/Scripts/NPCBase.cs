using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPCBase : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private int m_health;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(m_player.tag))
        {
            Hit();
        }
    }

    private void Hit()
    {
        m_health -= 100;

        if (m_health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
