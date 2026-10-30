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

/*<<<<<<< HEAD
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Kill();
        }
    }


    public void Kill()
    {
        // Kill Stuff
        print("kill");
=======*/

    private void Hit()
    {
        m_health -= 100;

        if (m_health <= 0)
        {
            OnDeath();
        }

/*>>>>>>> 6afb9dded98727058ed377dffd6e67b6d338bc7b*/

    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        m_player = Globals.GetCurrentPlayer();
    }
}
